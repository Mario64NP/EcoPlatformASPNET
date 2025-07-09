namespace EcoPlatform.DTOs.City
{
    public class CityFlatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CityFlatDTO(Models.City city)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));

            Id = city.Id;
            Name = city.Name;
            Region = city.Region;
            Country = city.Country;
            Latitude = city.Latitude;
            Longitude = city.Longitude;
        }
    }
}
