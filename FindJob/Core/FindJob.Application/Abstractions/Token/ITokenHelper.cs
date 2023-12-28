namespace FindJob.Application.Abstractions.Token
{
    public interface ITokenHelper
    {
        Token CreateAccessToken(string userId);

    }
}
