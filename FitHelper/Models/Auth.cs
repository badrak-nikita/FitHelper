using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class Auth
    {
        [Required(ErrorMessage = "Не вказан логiн")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не вказан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}