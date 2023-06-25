using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class Calories
    {
        public int Id { get; set; }
        [Required]
        public int Cal { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfNote { get; set; }
        public string? UserId { get; set; }
    }
}