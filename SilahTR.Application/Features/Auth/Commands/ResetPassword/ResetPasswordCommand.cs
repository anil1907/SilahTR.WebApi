using MediatR;
using SilahTR.Application.Common.Interfaces;

namespace SilahTR.Application.Features.Auth.Commands.ResetPassword;

public record ResetPasswordCommand : IRequest<bool>
{
    public string Email { get; init; }
    public string Token { get; init; }
    public string NewPassword { get; init; }
}

public class ResetPasswordCommandHandler(IAuthService authService) : IRequestHandler<ResetPasswordCommand, bool>
{
    public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await authService.ResetPasswordAsync(
            request.Email,
            request.Token,
            request.NewPassword);
    }
} 