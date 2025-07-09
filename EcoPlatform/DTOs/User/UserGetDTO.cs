using EcoPlatform.DTOs.Project;

namespace EcoPlatform.DTOs.User
{
    public class UserGetDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

        public ICollection<ProjectFlatDTO> Projects { get; set; } = [];

        public UserGetDTO(Models.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Id = user.Id;
            Username = user.Username;
            IsAdmin = user.IsAdmin;
            Projects = user.Projects?.Select(p => new ProjectFlatDTO(p)).ToList() ?? [];
        }
    }
}
