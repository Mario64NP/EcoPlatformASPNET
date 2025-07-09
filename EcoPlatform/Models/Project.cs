using EcoPlatform.DTOs.Project;

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

        public static Project FromDTO(ProjectUpsertDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                CityId = dto.CityId
            };
        }
    }
}
