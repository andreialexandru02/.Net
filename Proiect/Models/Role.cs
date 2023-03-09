using System.ComponentModel.DataAnnotations;

namespace _12_dec_2022.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string RoleName { get; set; }
    }
}
