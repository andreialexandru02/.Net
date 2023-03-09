using System.ComponentModel.DataAnnotations;

namespace AndreiAlexandru42.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Numele brandului este obligatoriu")]
        public string Nume { get; set; }


    }
}
