using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class Registration
    {
        [Required]
        [Display(Name = "Введiть iм'я")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Введiть логiн")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Введiть пароль")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Паролi не спiвпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Пiдтвердiть пароль")]
        public string? PasswordConfirm { get; set; }
    }
}
