namespace EcoPlatform.DTOs.User
{
    public class UserFlatDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public bool IsAdmin { get; set; } = false;

        public UserFlatDTO(Models.User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            Id = user.Id;
            Username = user.Username;
            IsAdmin = user.IsAdmin;
        }
    }
}
