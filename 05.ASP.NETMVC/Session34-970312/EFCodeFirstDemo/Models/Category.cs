using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo.Models
{
    [Table("Category", Schema = "Production")]
    public class Category
    {
        [Key]//, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        [NotMapped]
        public int ProductCount { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
