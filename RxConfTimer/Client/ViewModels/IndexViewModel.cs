using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DynamicData.Kernel;
using LanguageExt;
using static LanguageExt.Prelude;
using ReactiveUI;
using RxUnit = System.Reactive.Unit;
using RxConfTimer.Client.Data;
using RxConfTimer.Shared.Models;

namespace RxConfTimer.Client.ViewModels
{
    public class IndexViewModel : ReactiveObject
    {
        private readonly ILocalDataService _localData;
        private readonly ObservableAsPropertyHelper<Item> _deadline;
        
        public Item Deadline => _deadline.Value;

        public IndexViewModel(ILocalDataService localData)
        {
            _localData = localData;
            var list = LoadItemsFromServer();

            GetCurrentItem = ReactiveCommand.CreateFromTask(CurrentItem);
            _deadline = GetCurrentItem.ToProperty(this, x => x.Deadline, scheduler: RxApp.MainThreadScheduler);
        }

        public ReactiveCommand<RxUnit, Item> GetCurrentItem { get; }


        private Task<Item> CurrentItem()
        {
            var list =  LoadItemsFromServer();
            var result = list.FirstOrDefault(x => x.ScheduledTime > DateTime.Now);
            return Task.FromResult(result ?? list.First());
        }
        
        private static List<Item> LoadItemsFromServer()
        {
            var result = new List<Item>();
            var tryit = ServerData.TryGetItems().ToTryOption();
            tryit.Match(Some: x => result = x, None: () => { }, exception => throw exception);
            return result;
        }
    }
}