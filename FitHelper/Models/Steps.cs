using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class Steps
    {
        public int Id { get; set; }
        [Required]
        public int Step { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfNote { get; set; }
        public string? UserId { get; set; }
    }
}