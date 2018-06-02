using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.Models
{
    [Table("Photo", Schema = "Production")]
    public class ProductPhoto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Path { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
