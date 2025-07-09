namespace EcoPlatform.DTOs.Project
{
    public class ProjectUpsertDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CityId { get; set; }
    }
}
