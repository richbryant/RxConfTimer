using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using LanguageExt;
using static LanguageExt.Prelude;
using RxConfTimer.Shared.Models;

namespace RxConfTimer.Client.Data
{
    public static class ServerData
    {
        public static TryAsync<List<Item>> TryGetItems()
            => TryAsync(async () => await GetItems()
                .ConfigureAwait(false));

        public static async Task<List<Item>> GetItems()
            => await ItemsUrl
                .GetJsonAsync<List<Item>>()
                .ConfigureAwait(false);

        public static string ItemsUrl = "https://localhost:44382/api/items";
    }
}