using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Web.WebServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Web.WebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiamondController : ControllerBase
    {
        private readonly IMapper mapper =null;
        private readonly IDiamondRepository diamondRepository = null;
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly IConfiguration configuration;

        public DiamondController(IMapper mapper, IDiamondRepository diamondRepository, IConfiguration config)
        {
            this.mapper = mapper;
            this.diamondRepository = diamondRepository;
            this.configuration = config;
        }


        [HttpGet]
        public async Task<IActionResult> GetDiamondsAsync()
        {
            var data = await diamondRepository.GetDiamonds();

            var list = mapper.Map<IEnumerable<Web.Data.Dto.DiamondViewDto>>(data);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePhoto(Web.Data.Dto.DiamondViewDto itemModel) {

            await diamondRepository.DeletePhoto(itemModel.Id == 0 ? itemModel.ThumbId.GetValueOrDefault() : itemModel.Id);         
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddItem(Web.Data.Dto.DiamondViewDto itemModel) //, IFormFile file, IFormFile file2
        {

            Web.Data.Dto.ItemPhotosDto dtoPhoto = mapper.Map<Web.Data.Dto.ItemPhotosDto>(itemModel);

            //await Upload(folder, bookModel.CoverPhoto);
            dtoPhoto.ItemId = itemModel.ItemTypeId;
            dtoPhoto.CreatedAt = DateTime.Now;
            dtoPhoto.Position = diamondRepository.GetLastPosition(itemModel.ItemTypeId) + 1; //last active pos will be checked..
            dtoPhoto.IsActive = true;
            dtoPhoto.TypeId = 1; // photo

            Web.Data.Dto.ItemPhotosDto dtoThumb = mapper.Map<Web.Data.Dto.ItemPhotosDto>(itemModel);

            //await Upload(folder, bookModel.CoverPhoto);
            dtoThumb.ItemId = itemModel.ItemTypeId;
            dtoThumb.CreatedAt = DateTime.Now;
            dtoThumb.Position = diamondRepository.GetLastPosition(itemModel.ItemTypeId) + 1; //last active pos will be checked..
            dtoThumb.IsActive = true;
            dtoThumb.TypeId = 2; //thumb

            Web.Data.Dto.ItemPhotoPropertySetDto dtoSetMetal = new Web.Data.Dto.ItemPhotoPropertySetDto();
            dtoSetMetal.PropertyId = 1;
            dtoSetMetal.Value = itemModel.MetalValue;

            Web.Data.Dto.ItemPhotoPropertySetDto dtoSetShape = new Web.Data.Dto.ItemPhotoPropertySetDto();
            dtoSetShape.PropertyId = 2;
            dtoSetShape.Value = itemModel.ShapeValue;

            int[] ids = await diamondRepository.AddNewPhoto(dtoPhoto, dtoThumb, dtoSetMetal,dtoSetShape);

            return new OkObjectResult(new returnItem { photoId = ids[0], thumbId = ids[1] });
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm]string itemPhotoId, [FromForm] string itemThumbId, IFormFile filePhoto, IFormFile fileThumb)
        {

            string pathPhoto = itemPhotoId + "_" + filePhoto.FileName;

            string pathThumb = itemThumbId + "_" + fileThumb.FileName;

            string folderPhoto = Path.Combine(configuration.GetValue<string>(
                "FolderPath"), pathPhoto);

            string folderThumb = Path.Combine(configuration.GetValue<string>(
                "FolderPath"), pathThumb);

            await filePhoto.CopyToAsync(new FileStream(folderPhoto, FileMode.Create));

            await fileThumb.CopyToAsync(new FileStream(folderThumb, FileMode.Create));

            await diamondRepository.Upload(itemPhotoId, pathPhoto, itemThumbId, pathThumb);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddPicture([FromForm]string fileUploadID, IFormFile filePhoto)
        {
            //"fu$" + 1 + "$" + pos.itemTypeId + "$" + pos.metalValue + "$" + pos.shapeValue;
            string[] arr = fileUploadID.Split('-');

            string pictureTypeId = arr[1];  // picture or thumb
            string itemTypeId = arr[2];
            string metalType = arr[3];
            string shapeValue = arr[4];

            string pathPhoto = Guid.NewGuid() + "_" + filePhoto.FileName;

            string folderPhoto = Path.Combine(configuration.GetValue<string>(
                "FolderPath"), pathPhoto);

            await filePhoto.CopyToAsync(new FileStream(folderPhoto, FileMode.Create));

            await diamondRepository.AddPicture(int.Parse(itemTypeId), int.Parse(pictureTypeId), metalType, shapeValue, pathPhoto);

            return Ok();
        }
    } 
}