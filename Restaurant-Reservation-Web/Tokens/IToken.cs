namespace Restaurant_Reservation_Web.Tokens;

public interface IToken
{
    public string GenerateToken(string username, string password);

    public void ValidateToken();
}