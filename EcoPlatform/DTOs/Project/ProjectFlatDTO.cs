namespace EcoPlatform.DTOs.Project
{
    public class ProjectFlatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CityId { get; set; }

        public ProjectFlatDTO(Models.Project project)
        {
            if (project == null) throw new ArgumentNullException(nameof(project));

            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            CityId = project.CityId;
        }
    }
}
