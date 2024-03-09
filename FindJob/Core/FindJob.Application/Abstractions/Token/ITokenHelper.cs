namespace FindJob.Application.Abstractions.Token
{
    public interface ITokenHelper
    {
        string CreateAccessToken(string userId, List<String> roles);

    }
}
