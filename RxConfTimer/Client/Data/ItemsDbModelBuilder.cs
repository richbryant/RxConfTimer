using DnetIndexedDb.Models;
using System.Collections.Generic;

namespace RxConfTimer.Client.Data
{
    public static class ItemsDbModelBuilder
    {
        public static IndexedDbDatabaseModel GetItemDataModel() =>
            new IndexedDbDatabaseModel
            {
                Name = "ItemsData",
                Version = 1,
                Stores = new List<IndexedDbStore>
                {
                    new IndexedDbStore
                    {
                        Name = "items",
                        Key = new IndexedDbStoreParameter
                        {
                            KeyPath = "id",
                            AutoIncrement = false
                        },
                        Indexes = new List<IndexedDbIndex>
                        {
                            new IndexedDbIndex
                            {
                                Name = "id",
                                Definition = new IndexedDbIndexParameter
                                {
                                    Unique = true
                                }
                            },
                            new IndexedDbIndex
                            {
                                Name = "title",
                                Definition = new IndexedDbIndexParameter
                                {
                                    Unique = false
                                }
                            },
                            new IndexedDbIndex
                            {
                                Name = "scheduledTime",
                                Definition = new IndexedDbIndexParameter
                                {
                                    Unique = false
                                }
                            }
                        }
                    }
                },
                DbModelId = 0
            };
    }
}