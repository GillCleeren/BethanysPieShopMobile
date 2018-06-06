namespace BethanysPieShop.Mobile.Core.Contracts.Services.General
{
    public interface ISettingsService
    {
        void AddItem(string key, string value);
        string GetItem(string key);

        string UserNameSetting { get; set; }
        string UserIdSetting { get; set; }
    }
}
