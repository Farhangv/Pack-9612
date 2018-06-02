using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.Models
{
    [Table("Product", Schema = "Production")]
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50), Index(IsUnique = true), Required]
        //[Index(IsUnique = true)]
        public string Name { get; set; }
        public string Color { get; set; }
        [Column("Price")]
        public double ListPrice { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<ProductPhoto> Photos { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
