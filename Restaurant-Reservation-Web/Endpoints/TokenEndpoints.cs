using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Restaurant_Reservation_Web.Tokens;

namespace Restaurant_Reservation_Web.Endpoints;

public static class TokenEndpoints
{
    public static void MapTokenEndpoints(this WebApplication app, string secertKey)
    {
        app.MapGet("/token/{username}", (string username) =>
        {
            IToken token = new JwtTokenGenerator(secertKey, new JwtBearerOptions());
            return Results.Ok(token.GenerateToken(username));
        });
    }
}