namespace CRUD.Application.DTOs.Response.Login
{
    public class LoginResponseDTO
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; } = null!;
        public int SessionID { get; set; }
    }
}
