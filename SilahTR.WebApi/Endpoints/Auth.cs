using MediatR;
using SilahTR.Application.Features.Auth.Commands.Login;
using SilahTR.Application.Features.Auth.Commands.Register;
using SilahTR.Application.Features.Auth.Dtos;
using SilahTR.WebApi.Infrastructure;

namespace SilahTR.WebApi.Endpoints
{
    public class Auth : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapPost("/auth/login", Login);
            
            app.MapPost("/auth/register", Register);
        }
        
        private async Task<AuthResponse> Login(ISender sender, LoginCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }
        
        private async Task<AuthResponse> Register(ISender sender, RegisterCommand command, CancellationToken cancellationToken)
        {
            return await sender.Send(command, cancellationToken);
        }
    }
}

