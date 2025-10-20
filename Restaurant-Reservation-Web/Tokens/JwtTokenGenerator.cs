using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Restaurant_Reservation_Web.Tokens;

public class JwtTokenGenerator : IToken
{
    private string _secertKey;
    private JwtBearerOptions _options;

    public JwtTokenGenerator(string secertKey, JwtBearerOptions options)
    {
        _secertKey = secertKey;
        _options = options;
    }

    public string GenerateToken(string username)
    {
        var key = Encoding.ASCII.GetBytes(_secertKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


    public void ValidateToken()
    {
        var key = Encoding.ASCII.GetBytes(_secertKey);
        var tokenHandler = new JwtSecurityTokenHandler();
        _options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secertKey))
        };
    }
}