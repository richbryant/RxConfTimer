using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;
using RxConfTimer.Shared.Models;

namespace RxConfTimer.Client.Data
{
    public interface ILocalDataService
    {
        TryAsync<int> TryInit();
        TryAsync<string> TryAddItems(List<Item> items);
        TryAsync<List<Item>> TryGetItems();
    }

    public class LocalDataService : ILocalDataService
    {
        private readonly ItemDataIndexedDb _database;

        public LocalDataService(ItemDataIndexedDb database) => _database = database;

        public TryAsync<int> TryInit() => TryAsync(async () => await Init());

        public TryAsync<string> TryAddItems(List<Item> items) => TryAsync(async () => await AddServerItems(items));

        public TryAsync<List<Item>> TryGetItems() => TryAsync(async () => await GetLocalItems());

        public async Task<int> Init() => await _database.OpenIndexedDb();

        public async Task<string> AddServerItems(List<Item> items) => await _database.AddItems<Item>("items", items);

        public async Task<List<Item>> GetLocalItems() => await _database.GetAll<Item>("items");
    }
}