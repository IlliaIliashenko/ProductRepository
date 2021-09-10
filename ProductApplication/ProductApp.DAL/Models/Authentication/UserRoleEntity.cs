namespace ProductApp.DAL.Models.Authentication
{
    public class UserRoleEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}