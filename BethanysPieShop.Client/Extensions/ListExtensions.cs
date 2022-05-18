using System.Collections.ObjectModel;

namespace BethanysPieShop.Client.Extensions;

public static class ListExtensions
{
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
    {
        return new ObservableCollection<T>(list);
    }
}