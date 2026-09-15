using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Data;
using Stockastic.UI;
using System;
class Program
{
    static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

        var connectionString = config.GetConnectionString("PostgreSQL");
        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        using var dbContext = new ApplicationDbContext(dbContextOptions);
        Console.WriteLine(dbContext.Database.CanConnect());

        App app = new App();
        app.Run();
    }
}

