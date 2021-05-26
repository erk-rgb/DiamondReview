using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data.Dto;

namespace Web.WebServices.Repository
{
    public interface IDiamondRepository
    {
        Task<int[]> AddNewPhoto(ItemPhotosDto modelPhoto, ItemPhotosDto modelThumb, Web.Data.Dto.ItemPhotoPropertySetDto modelMetal, Web.Data.Dto.ItemPhotoPropertySetDto modelShape);
        Task<List<Web.Data.Dto.DiamondViewDto>> GetDiamonds();
        Task<Boolean> Upload(string itemPhotoID, string photoName, string itemThumbID, string thumbName);
        int GetLastPosition(int itemTypeID);
        Task<bool> DeletePhoto(int photoID);
        Task<Boolean> AddPicture(int itemtypeID, int pictureTypeId, string metalValue, string shapeValue, string photoName);
    }
}
