using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RegistDate { get; set; }
    }
}