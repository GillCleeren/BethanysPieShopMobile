namespace BethanysPieShop.Client.Exceptions;

public class ServiceAuthenticationException : Exception
{
    public string Content { get; set; }
    public ServiceAuthenticationException(string content)
    {
        Content = content;
    }
}