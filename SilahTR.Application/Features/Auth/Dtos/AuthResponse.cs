namespace SilahTR.Application.Features.Auth.Dtos
{
    public class AuthResponse
    {
        public bool IsSuccess { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Message { get; set; }

        public AuthResponse()
        {
            Roles = new List<string>();
        }
    } 
}
