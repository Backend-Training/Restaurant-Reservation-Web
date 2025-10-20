namespace Restaurant_Reservation_Web.Tokens;

public interface IToken
{
    public string GenerateToken(string username);

    public void ValidateToken();
}