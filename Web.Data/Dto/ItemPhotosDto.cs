using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Dto
{
    [Table("ItemPhotos")]
    public class ItemPhotosDto
    {
        [Key]
        public int Id { get; set; }

        public int? ItemId { get; set; }

        public int TypeId { get; set; }

        public string FileName { get; set; }

        public int? Position { get; set; }

        public string Alt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
