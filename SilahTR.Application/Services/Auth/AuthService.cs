using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using SilahTR.Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilahTR.Domain.Entities.Identity;
using Microsoft.IdentityModel.Tokens;
using SilahTR.Application.Features.Auth.Dtos;

namespace SilahTR.Application.Services.Auth;

public class AuthService(
    UserManager<ApplicationUser> userManager,
    IConfiguration configuration)
    : IAuthService
{
    public async Task<AuthResponse> LoginAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            return new AuthResponse { IsSuccess = false, Message = "User not found." };

        if (!await userManager.CheckPasswordAsync(user, password))
            return new AuthResponse { IsSuccess = false, Message = "Invalid password." };

        var token = await GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        return new AuthResponse
        {
            IsSuccess = true,
            AccessToken = token,
            RefreshToken = refreshToken,
            ExpiresIn = DateTime.UtcNow.AddHours(1),
            UserName = user.UserName,
            Email = user.Email,
            Roles = (await userManager.GetRolesAsync(user)).ToList()
        };
    }

    public async Task<AuthResponse> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        var existingUser = await userManager.FindByEmailAsync(email);
        if (existingUser != null)
            return new AuthResponse { IsSuccess = false, Message = "User already exists." };

        var user = new ApplicationUser
        {
            Email = email,
            UserName = email,
            FirstName = firstName,
            LastName = lastName
        };

        var result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
            return new AuthResponse { IsSuccess = false, Message = string.Join(", ", result.Errors.Select(e => e.Description)) };

        await userManager.AddToRoleAsync(user, "User");

        var token = await GenerateJwtToken(user);
        var refreshToken = GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        return new AuthResponse
        {
            IsSuccess = true,
            AccessToken = token,
            RefreshToken = refreshToken,
            ExpiresIn = DateTime.UtcNow.AddHours(1),
            UserName = user.UserName,
            Email = user.Email,
            Roles = new List<string> { "User" }
        };
    }

    public async Task<bool> ForgotPasswordAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = $"{configuration["AppUrl"]}/reset-password?email={email}&token={Uri.EscapeDataString(token)}";

        // await _emailService.SendEmailAsync(
        //     email,
        //     "Reset Password",
        //     $"Please reset your password by clicking here: {resetLink}");

        return true;
    }

    public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            return false;

        var result = await userManager.ResetPasswordAsync(user, token, newPassword);
        return result.Succeeded;
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            return new AuthResponse { IsSuccess = false, Message = "Invalid refresh token." };

        var token = await GenerateJwtToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
        await userManager.UpdateAsync(user);

        return new AuthResponse
        {
            IsSuccess = true,
            AccessToken = token,
            RefreshToken = newRefreshToken,
            ExpiresIn = DateTime.UtcNow.AddHours(1),
            UserName = user.UserName,
            Email = user.Email,
            Roles = (await userManager.GetRolesAsync(user)).ToList()
        };
    }

    public async Task<bool> RevokeTokenAsync(string refreshToken)
    {
        var user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        if (user == null)
            return false;

        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;
        await userManager.UpdateAsync(user);

        return true;
    }
    
    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        var roles = await userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.GivenName, user.FirstName),
            new(ClaimTypes.Surname, user.LastName)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string GenerateRefreshToken()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}