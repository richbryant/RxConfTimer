using System;
using LinqToDB.Mapping;

namespace RxConfTimer.Shared.Models
{
    public class Item
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}