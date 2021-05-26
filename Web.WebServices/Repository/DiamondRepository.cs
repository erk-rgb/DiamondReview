using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Dto;
using Web.WebServices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Web.WebServices.Repository
{
    public class DiamondRepository : IDiamondRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper mapper;
        private readonly DiamondContext _context = null;

        public DiamondRepository(DiamondContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<int[]> AddNewPhoto(ItemPhotosDto modelPhoto, ItemPhotosDto modelThumb, ItemPhotoPropertySetDto setMetalModel, ItemPhotoPropertySetDto setShapeModel)
        {
            await _context.ItemPhotos.AddAsync(modelPhoto);
            await _context.SaveChangesAsync();
            setMetalModel.ItemPhotoId = modelPhoto.Id;
            setShapeModel.ItemPhotoId = modelPhoto.Id;
            await _context.ItemPhotoPropertySet.AddRangeAsync(new ItemPhotoPropertySetDto[] { setMetalModel, setShapeModel });
            await _context.SaveChangesAsync();
            await _context.ItemPhotos.AddAsync(modelThumb);
            await _context.SaveChangesAsync();
            ItemPhotoPropertySetDto thumbMetalModel = new ItemPhotoPropertySetDto();
            ItemPhotoPropertySetDto thumbShapeModel = new ItemPhotoPropertySetDto();
            thumbMetalModel.PropertyId = setMetalModel.PropertyId;
            thumbMetalModel.Value = setMetalModel.Value;
            thumbShapeModel.PropertyId = setShapeModel.PropertyId;
            thumbShapeModel.Value = setShapeModel.Value;
            thumbMetalModel.ItemPhotoId = modelThumb.Id;
            thumbShapeModel.ItemPhotoId = modelThumb.Id;
            await _context.ItemPhotoPropertySet.AddRangeAsync(new ItemPhotoPropertySetDto[] { thumbMetalModel, thumbShapeModel });
            await _context.SaveChangesAsync();

            return new int[] { modelPhoto.Id, modelThumb.Id };
        }

        public async Task<bool> AddPicture(int itemtypeID, int pictureTypeId, string metalValue, string shapeValue, string photoName)
        {
            ItemPhotosDto photoDto = (from t1 in _context.ItemPhotos
                                      join t2 in _context.ItemPhotoPropertySet on t1.Id equals t2.ItemPhotoId
                                      join t3 in _context.ItemPhotoPropertySet on t2.ItemPhotoId equals t3.ItemPhotoId
                                      where t1.ItemId == itemtypeID && t2.Value.Replace(" ","") == metalValue && t3.Value.Replace(" ", "") == shapeValue && t1.IsActive == false && t1.TypeId == pictureTypeId
                                      select t1).LastOrDefault();

            if (photoDto == null)
            {
                photoDto = new ItemPhotosDto { ItemId = itemtypeID, IsActive = true, CreatedAt = DateTime.Now, FileName = photoName, Position = GetLastPosition(itemtypeID) + 1, TypeId = pictureTypeId };
                await _context.AddAsync(photoDto);
                await _context.SaveChangesAsync();
                ItemPhotoPropertySetDto dtoMetal = new ItemPhotoPropertySetDto();
                dtoMetal.ItemPhotoId = photoDto.Id;
                dtoMetal.PropertyId = 1;
                ItemPhotoPropertySetDto dtoTempMetal = await _context.ItemPhotoPropertySet.FirstAsync(t => t.Value.Replace(" ", "") == metalValue);
                dtoMetal.Value = dtoTempMetal.Value;
                ItemPhotoPropertySetDto dtoShape = new ItemPhotoPropertySetDto();
                dtoShape.ItemPhotoId = photoDto.Id;
                dtoShape.PropertyId = 2;
                ItemPhotoPropertySetDto dtoTempShape = await _context.ItemPhotoPropertySet.FirstAsync(t => t.Value.Replace(" ", "") == shapeValue);
                dtoShape.Value = dtoTempShape.Value;

                await _context.ItemPhotoPropertySet.AddRangeAsync(new ItemPhotoPropertySetDto[] { dtoMetal, dtoShape });
                await _context.SaveChangesAsync();
                return true;
            }

            photoDto.ModifiedAt = DateTime.Now;
            photoDto.IsActive = true;
            photoDto.FileName = photoName;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeletePhoto(int photoID)
        {
            ItemPhotosDto photoDto = _context.ItemPhotos.SingleOrDefault(t => t.Id == photoID);
            photoDto.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Web.Data.Dto.DiamondViewDto>> GetDiamonds()
        {
            return await _context.Diamonds.ToListAsync();
        }

        public int GetLastPosition(int itemTypeID)
        {
            return _context.ItemPhotos.Where(t => t.ItemId == itemTypeID && t.IsActive == true).LastOrDefault() == null ? 0 : _context.ItemPhotos.Where(t => t.ItemId == itemTypeID && t.IsActive == true).LastOrDefault().Position.GetValueOrDefault();
        }

        public async Task<bool> Upload(string itemPhotoID, string photoName, string itemThumbID, string thumbName)
        {
            ItemPhotosDto photoDto = _context.ItemPhotos.SingleOrDefault(t => t.Id == int.Parse(itemPhotoID));
            photoDto.FileName = photoName;
            ItemPhotosDto thumbDto = _context.ItemPhotos.SingleOrDefault(t => t.Id == int.Parse(itemThumbID));
            thumbDto.FileName = thumbName;
            await _context.SaveChangesAsync();
            //await _context.ItemPhotos.Update(dto);
            return true;
        }
    }
}
