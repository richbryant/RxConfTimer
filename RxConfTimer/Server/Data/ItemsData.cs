using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageExt;
using LinqToDB;
using RxConfTimer.Shared.Models;
using static LanguageExt.Prelude;

namespace RxConfTimer.Server.Data
{
    public interface IItemsData
    {
        public TryAsync<List<Item>> TryGetItems();
        public TryAsync<int> TryUpdateItem(Item item);
    }

    public class ItemsData : IItemsData
    {
        private readonly AppDataConnection _connection;

        public ItemsData(AppDataConnection connection) => _connection = connection;

        public TryAsync<List<Item>> TryGetItems() => TryAsync(async () => await GetItems());

        public TryAsync<int> TryUpdateItem(Item item) => TryAsync(async () => await UpdateItem(item));

        public Task<List<Item>> GetItems() => _connection.Items.ToListAsync();

        public Task<int> UpdateItem(Item item) => _connection.UpdateAsync(item);

    }
}