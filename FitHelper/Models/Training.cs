using System.ComponentModel.DataAnnotations;

namespace FitHelper.Models
{
    public class Training
    {
        public int Id { get; set; }
        [Required]
        public string Exercise { get; set; }
        public string Approaches { get; set; }
        public string Repeats { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTrain { get; set; }
        public string? UserId { get; set; }
    }
}