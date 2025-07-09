using EcoPlatform.DTOs.User;

namespace EcoPlatform.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public static User FromDTO(UserUpsertDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
            };
        }
    }
}
