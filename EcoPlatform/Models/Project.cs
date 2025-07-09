namespace EcoPlatform.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int CityId { get; set; }
        public City City { get; set; } = null!;

        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
