namespace EcoPlatform.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Country { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
