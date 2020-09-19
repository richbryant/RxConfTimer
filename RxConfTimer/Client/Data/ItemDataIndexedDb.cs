using DnetIndexedDb;
using Microsoft.JSInterop;

namespace RxConfTimer.Client.Data
{
    public class ItemDataIndexedDb : IndexedDbInterop
    {
        public ItemDataIndexedDb(IJSRuntime jsRuntime, IndexedDbOptions<ItemDataIndexedDb> options) : base(jsRuntime, options)
        { }
    }
}