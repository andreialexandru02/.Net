using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_dec_2022.Models
{
    public class Reply
    {
        [Key]
        public int IdReply { get; set; }
        public int IdThread { get; set; }
        public int? IdUser { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

       public virtual Thread? Thread { get; set; }

       public virtual ApplicationUser User { get; set; }


        //[NotMapped]
        // public IEnumerable<SelectListItem>? Thrd { get; set; }
    }
}
