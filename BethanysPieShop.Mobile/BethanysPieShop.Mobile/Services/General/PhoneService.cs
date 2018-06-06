using BethanysPieShop.Mobile.Core.Contracts.Services.General;
using Plugin.Messaging;

namespace BethanysPieShop.Mobile.Core.Services.General
{
    public class PhoneService: IPhoneService
    {
        public void MakePhoneCall()
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall("5554885002");
        }
    }
}
