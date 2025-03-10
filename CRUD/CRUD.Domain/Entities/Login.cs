namespace CRUD.Domain.Entities
{
    public partial class Login
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public int SessionID { get; set; }
    }
}
