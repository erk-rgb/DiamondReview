using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Data.Dto
{
    [Table("Types")]
    public class TypesDto
    {
        [Key]
        public int Id { get; set; }  //Item itself

        public string Name { get; set; }
    }
}
