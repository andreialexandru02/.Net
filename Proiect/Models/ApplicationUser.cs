using Microsoft.AspNetCore.Identity;

namespace _12_dec_2022.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Thread>? Threads { get; set; }

        public virtual ICollection<Reply>? Replies { get; set; }
    }
}
