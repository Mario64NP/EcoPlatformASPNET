using EcoPlatform.DTOs.City;

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

        public static City FromDTO(CityUpsertDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new City
            {
                Name = dto.Name,
                Region = dto.Region,
                Country = dto.Country,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };
        }
    }
}
