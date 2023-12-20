namespace FindJob.Application.Abstractions.Token
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
