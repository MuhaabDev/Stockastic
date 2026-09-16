using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Data;
using Stockastic.Services;
using Stockastic.Services.Authentication;
using Stockastic.UI;
using Stockastic.Services.Trading;
using Stockastic.Services.Settings;
class Program
{
    static async Task Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

        var connectionString = config.GetConnectionString("PostgreSQL");
        var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        using var context = new ApplicationDbContext(dbContextOptions);
        //Console.WriteLine(dbContext.Database.CanConnect());
        // Services
        var walletService = new WalletService(context);
        var tradingService = new TradingService(context);
        var settingService = new SettingsService(context);

        // Authentication Services
        var userRepository = new UserRepository(context);
        var passwordHasher = new PasswordHasher();
        var loginUser = new LoginUser(userRepository , passwordHasher);
        var authService = new AuthService(userRepository , passwordHasher , loginUser);

        // Menus
        var setting = new Settings(settingService) ;
        var accountMenu = new AccountMenu(authService);
        var userMenu = new UserMenu(walletService , setting);

        // Main menu
        var mainMenu = new MainMenu(accountMenu,userMenu);

        // App
        var app = new App(mainMenu);
        await app.Show();
    }
}
/*
  Get-ChildItem -Recurse -Include *.cs | Get-Content | Measure-Object -Line
                     ApplicationDbContext
                   /        |         \
                  /         |          \
                 ↓          ↓           ↓
           AuthService  AccountService  PortfolioService
                 ↓          ↓           ↓
           AccountMenu   UserMenu     UserMenu
                              \          /
                               \        /
                                ↓      ↓
                               MainMenu
                                  ↓
                                 App
 */