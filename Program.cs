using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stockastic.Data;
using Stockastic.Services;
using Stockastic.Services.Authentication;
using Stockastic.UI.Trading_Page;
using Stockastic.UI.User_Page;
using Stockastic.Services.Trading;
using Stockastic.Services.Settings;
using Stockastic.UI;
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

        // TODO : Make - WatchlistMenu , TradeMenu  , HoldingsMenu and give them to trading menu
        var tradingMenu = new TradingMenu(tradingService);
        var userMenu = new UserMenu(walletService , setting , tradingMenu);
        var accountMenu = new AccountMenu(authService);
        var mainMenu = new MainMenu(accountMenu,userMenu);

        // App
        var app = new App(mainMenu);
        await app.Show();
    }
}
// TODO : I want you before running to update database : every user should have watchlist table
// TODO : if everything is created successfully like if a user is created should he have a ready based holding initialized with a count zero or only be created when he buy or sell
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