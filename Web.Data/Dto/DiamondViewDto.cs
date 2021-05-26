using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Dto
{
    [Table("DiamondView")]
    public class DiamondViewDto
    {
        [Key]
        public Int64 RowNr { get; set; }

        public int Id { get; set; }  //Item itself

        public string FileName { get; set; }

        public int ItemTypeId { get; set; }  // Engagement or Wedding

        public string ItemType { get; set; }

        public string Type { get; set; }

        public int TypeId { get; set; }  //  //  Photo and Thumbs uploaded separately for one item??

        public int MetalPropertyId { get; set; }

        public string MetalValue { get; set; }  //

        public int ShapePropertyId { get; set; }

        public string ShapeValue { get; set; }  //

        public int? Position { get; set; }

        public int? ThumbId { get; set; }  //

        public string Thumb { get; set; }  // //  Photo and Thumbs uploaded separately for one item??


    }
}
