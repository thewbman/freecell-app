using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreecellApp.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

        Task<IEnumerable<T>> GetAllParents(T item);
        Task<IEnumerable<T>> GetAllChildren(T item);

    }
}
