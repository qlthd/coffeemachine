using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoffeeMachine.Data { 
    /// <summary>
    /// Factory for creating Entities Context
    /// </summary>
    public class CoffeeMachineDbContextFactory : IDesignTimeDbContextFactory<CoffeeMachineContext>
    {
        public CoffeeMachineContext CreateDbContext(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            // Getting config file
            var builder = new ConfigurationBuilder()
                               .SetBasePath(path)
                               .AddJsonFile("appsettings.json");


            var config = builder.Build();

            // Getting ConnectionString value inside config file
            var connectionString = config.GetConnectionString("DefaultContext");

            DbContextOptionsBuilder<CoffeeMachineContext> optionBuilder = new DbContextOptionsBuilder<CoffeeMachineContext>();
            
            // SQL Server connection
            optionBuilder.UseSqlServer(connectionString);

            return new CoffeeMachineContext(optionBuilder.Options);
        }
    }
}
