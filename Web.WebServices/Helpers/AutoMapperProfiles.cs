using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.WebServices.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Web.Data.Dto.DiamondViewDto, Web.Data.Dto.ItemPhotosDto>();
            CreateMap<Web.Data.Dto.ItemPhotosDto, Web.Data.Dto.DiamondViewDto>();
        }
    }
}
