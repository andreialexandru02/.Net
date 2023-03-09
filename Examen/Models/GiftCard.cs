using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndreiAlexandru42.Models
{
    public class GiftCard
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Denumirea este obligatorie")]
        public string Denumire { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        public string Descriere { get; set; }

        [Required(ErrorMessage = "Data expirarii este obligatorie")]
        public DateTime DataExp{ get; set; }

        [Required(ErrorMessage = "Procentul este obligatoriu")]
        public int Procent { get; set; }

        [Required(ErrorMessage = "Id-ul brandului este obligatoriu")]
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }


        [NotMapped]
        public IEnumerable<SelectListItem>? Brd { get; set;}
    }
}
