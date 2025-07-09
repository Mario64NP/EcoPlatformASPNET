using EcoPlatform.DTOs.City;

namespace EcoPlatform.DTOs.Project
{
    public class ProjectGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public CityFlatDTO City { get; set; } = null!;
        public ProjectGetDTO(Models.Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));

            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            City = new CityFlatDTO(project.City);
        }
    }
}
