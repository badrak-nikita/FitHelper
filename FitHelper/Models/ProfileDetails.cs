namespace FitHelper.Models
{
    public class ProfileDetails
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public byte[]? Image { get; set; }
        public int calorie_goal { get; set; }
        public double water_goal { get; set; }
        public int step_goal { get; set; }
        public User? User { get; set; }
    }
}