

namespace Stock_app.Services
{
    public interface IFinnhubService
    {
        Dictionary<string, object>? GetCompanyProfile(string stockSymbol);
        Dictionary<string, object>? GetStockPriceQuote(string stockSymbol);
    }
}
