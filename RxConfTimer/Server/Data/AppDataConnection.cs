using System.Security.Cryptography.X509Certificates;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.AspNetCore.Http.Features;
using RxConfTimer.Shared.Models;

namespace RxConfTimer.Server.Data
{
    public class AppDataConnection: DataConnection
    {
        public AppDataConnection(LinqToDbConnectionOptions<AppDataConnection> options)
            :base(options)
        { }

        public ITable<Item> Items => GetTable<Item>();
    }
}