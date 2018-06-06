using System;

namespace BethanysPieShop.Mobile.Core.Exceptions
{
    public class ServiceAuthenticationException: Exception
    {
        public string Content { get; set; }
        public ServiceAuthenticationException(string content)
        {
            Content = content;
        }
    }
}
