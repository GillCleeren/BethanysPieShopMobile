using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.Constants
{
    public class ApiConstants
    {
#if WINDOWS10_0_17763_0_OR_GREATER
        public const string BaseImagesUrl = "http://localhost:5002/images/";
        public const string BaseApiUrl = "http://localhost:5000/";
#else
        // EMULATOR
        //public const string BaseImagesUrl = "http://10.0.2.2:5002/images/";
        //public const string BaseApiUrl = "http://10.0.2.2:5000/";

        // LOCAL API WITH DEVICE
        public const string BaseImagesUrl = "http://192.168.0.112:5002/images/";
        public const string BaseApiUrl = "http://192.168.0.112:5000/";
#endif

        //public const string BaseApiUrl = "https://bps-pxl.azurewebsites.net/";
        public const string CatalogEndpoint = "api/catalog/pies/";
        public const string PiesOfTheWeekEndpoint = "api/catalog/piesoftheweek/";
        public const string ShoppingCartEndpoint = "api/shoppingcart";
        public const string AddShoppingCartItemEndpoint = "api/shoppingcart/";
        public const string AddContactInfoEndpoint = "api/contact";
        public const string PlaceOrderEndpoint = "api/order";
        public const string RegisterEndpoint = "api/authentication/register";
        public const string AuthenticateEndpoint = "api/authentication/authenticate";
    }
}
