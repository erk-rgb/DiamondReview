using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Dto
{
    [Table("ItemPhotoPropertySet")]
    public class ItemPhotoPropertySetDto
    {
        [Key]
        public int Id { get; set; }  //Item itself

        public int  ItemPhotoId { get; set; }

        public int PropertyId { get; set; }

        public string Value { get; set; }
    }
}
