using Plugin.Connectivity.Abstractions;

namespace BethanysPieShop.Mobile.Core.Contracts.Services.General
{
    public interface IConnectionService
    {
        bool IsConnected { get; }
        event ConnectivityChangedEventHandler ConnectivityChanged;
    }
}
