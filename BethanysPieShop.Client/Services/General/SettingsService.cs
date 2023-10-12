using BethanysPieShop.Client.Contracts.Services.General;
using Microsoft.Maui.Storage;

namespace BethanysPieShop.Client.Services.General;

public class SettingsService : ISettingsService
{
    private const string UserName = "UserName";
    private const string UserId = "UserId";

    public void AddItem(string key, string value)
    {
        Preferences.Default.Set(key, value);
    }

    public string GetItem(string key)
    {
        return Preferences.Get(key, string.Empty);
    }

    public string UserNameSetting
    {
        get => GetItem(UserName);
        set => AddItem(UserName, value);
    }

    public string UserIdSetting
    {
        get => GetItem(UserId);
        set => AddItem(UserId, value);
    }
}
