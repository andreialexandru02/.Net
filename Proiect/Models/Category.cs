using System.ComponentModel.DataAnnotations;

namespace _12_dec_2022.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Numele categoriei este obligatoriu")]
        public string CategoryName { get; set; }
        public virtual ICollection<Models.Thread>? Thread { get; set; }

    }
}
