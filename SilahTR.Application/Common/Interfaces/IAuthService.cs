using SilahTR.Application.Features.Auth.Dtos;

namespace SilahTR.Application.Common.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(string email, string password);
    Task<AuthResponse> RegisterAsync(string email, string password, string firstName, string lastName);
    Task<bool> ForgotPasswordAsync(string email);
    Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    Task<AuthResponse> RefreshTokenAsync(string refreshToken);
    Task<bool> RevokeTokenAsync(string refreshToken);
} 