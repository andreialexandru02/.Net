using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_dec_2022.Models
{
    public class Thread
    {
        [Key]
        public int IdThread { get; set; }
        public int IdCategory { get; set; }
        public virtual Category? Category { get; set; }

        public string? IdUser { get; set; }
        [Required(ErrorMessage = "Continutul este obligatoriu")]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Reply>? Replies { get; set; }
        
        [NotMapped]
        public IEnumerable<SelectListItem>? Categ { get; set; }

        public virtual ApplicationUser? User { get; set; }

    }
}
