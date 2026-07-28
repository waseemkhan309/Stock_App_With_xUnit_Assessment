

using Stock_app.Services;

namespace Stock_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();


            //Services
            builder.Services.AddControllersWithViews();
            builder.Services.Configure<TradeOptions>(builder.Configuration.GetSection("TradingOptions"));
            builder.Services.AddSingleton<IStocksService, StockServices>();
            builder.Services.AddSingleton<IFinnhubService, FinnhubService>();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
