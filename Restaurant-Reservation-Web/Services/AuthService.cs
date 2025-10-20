using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Reservation_Web.Tokens;

namespace Restaurant_Reservation_Web.Services;

public class AuthService : IAuthService
{
    private WebApplicationBuilder _builder;

    public AuthService(WebApplicationBuilder builder)
    {
        _builder = builder;
    }

    public void Configure()
    {
        _builder.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                IToken jwtTokenValidator = new JwtTokenGenerator(_builder.Configuration["JWT:secertKey"], options);
                jwtTokenValidator.ValidateToken();
            });
        _builder.Services.AddAuthorization();
    }
}