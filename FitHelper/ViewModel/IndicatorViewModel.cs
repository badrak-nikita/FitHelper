using FitHelper.Models;
using System.ComponentModel.DataAnnotations;

namespace FitHelper.ViewModel
{
    public class IndicatorViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfNote { get; set; }
        public string? UserId { get; set; }
        public List<Calories> Calories { get; set; }
        public int TotalCalories { get; set; }
        public List<Water> Water { get; set; }
        public double TotalLiters { get; set; }
        public List<Steps> Steps { get; set; }
        public int TotalSteps { get; set; }
    }
}