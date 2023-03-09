using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeatherShop.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        
        [Required(ErrorMessage = "Numarul de produse este obligatoriu")]
        public int NumberOfProducts { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public virtual Product? Product { get; set; }
    }
}
