using MediatR;
using SilahTR.Application.Common.Interfaces;

namespace SilahTR.Application.Features.Auth.Commands.ForgotPassword;

public record ForgotPasswordCommand : IRequest<bool>
{
    public string Email { get; init; }
}

public class ForgotPasswordCommandHandler(IAuthService authService) : IRequestHandler<ForgotPasswordCommand, bool>
{
    public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        return await authService.ForgotPasswordAsync(request.Email);
    }
} 