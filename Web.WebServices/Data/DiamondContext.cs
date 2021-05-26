using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.WebServices.Data
{

    public class DiamondContext: DbContext
    {
        public DiamondContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Web.Data.Dto.DiamondViewDto> Diamonds { get; set; }
        public DbSet<Web.Data.Dto.TypesDto> Types { get; set; }
        public DbSet<Web.Data.Dto.ItemPhotosDto> ItemPhotos { get; set; }
        public DbSet<Web.Data.Dto.ItemPhotoPropertySetDto> ItemPhotoPropertySet { get; set; }

    }
}
