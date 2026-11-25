namespace AddisEatsNew.Api.DTOs
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string TokenType { get; set; } = "Bearer";
        public DateTime ExpiresAtUtc { get; set; }
    }
}
