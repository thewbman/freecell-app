using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreecellApp.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<List<T>> GetItemsAsync(bool forceRefresh = false);


        Task<IEnumerable<T>> GetAllParents(T item);
        Task<IEnumerable<T>> GetAllChildren(T item);

    }
}
