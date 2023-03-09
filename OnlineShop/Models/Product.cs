using System.ComponentModel.DataAnnotations;

namespace LeatherShop.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
