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
using Stockastic.Services.Trading_Service;
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
        var stockService = new StockService(context);
        var walletService = new WalletService(context);
        var settingService = new SettingsService(context);
        var portfolioService = new PortfolioService(context);
        var tradingService = new TradingService(stockService , walletService , context , portfolioService);
        var watchlistService = new WatchlistService(context);

        // Authentication Services
        var userRepository = new UserRepository(context);
        var passwordHasher = new PasswordHasher();
        var loginUser = new LoginUser(userRepository , passwordHasher);
        var authService = new AuthService(userRepository , passwordHasher , loginUser);

        // Menus
        var setting = new Settings(settingService) ;
        var watctlistMenu = new WatchlistMenu(watchlistService, stockService);
        var tradeMenu = new TradeMenu(tradingService , stockService , portfolioService);
        var holdingMenu = new HoldingsMenu(portfolioService , stockService);
        var tradingMenu = new TradingMenu(watctlistMenu , tradeMenu , holdingMenu);
        var userMenu = new UserMenu(walletService , setting , tradingMenu);
        var accountMenu = new AccountMenu(authService);
        var mainMenu = new MainMenu(accountMenu,userMenu);

        // App
        var app = new App(mainMenu);
        await app.Show();
    }
}

// TODO : problem with getting stock price to buy it
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