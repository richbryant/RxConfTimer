using System.Threading.Tasks;
using DnetIndexedDb;
using Flurl.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RxConfTimer.Client.Data;
using RxConfTimer.Client.ViewModels;

namespace RxConfTimer.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddIndexedDbDatabase<ItemDataIndexedDb>(options => options.UseDatabase(ItemsDbModelBuilder.GetItemDataModel()));

            FlurlHttp.Configure(settings => settings.HttpClientFactory = new BlazorHttpClientFactory());
            builder.Services.AddTransient<ILocalDataService, LocalDataService>();
            builder.Services.AddTransient<IndexViewModel>();
            await builder.Build().RunAsync();
        }
    }
}
