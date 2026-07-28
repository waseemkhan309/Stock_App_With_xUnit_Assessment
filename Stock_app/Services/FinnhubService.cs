using System.Text.Json;

namespace Stock_app.Services
{
    public class FinnhubService : IFinnhubService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;


        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public Dictionary<string, object>? GetCompanyProfile(string stockSymbol)
        {
            // create httpclient
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // create http request
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}") //URI includes the secret token
            };


            // send request
            HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

            // read the response
            string responseBody = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();

            // convert the response from JSON to Dictionary
            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(responseBody);


            if(responseDictionary == null)
            {
                throw new InvalidOperationException("No response from server");
            }

            if (responseDictionary.ContainsKey("error"))
            {
                throw new InvalidOperationException(Convert.ToString( responseDictionary["error"]));
            }

            return responseDictionary;

            /*
            User Secrets:
            dotnet user-secrets init --project StockMarketSolution
            dotnet user-secrets set "FinnhubToken" "cc676uaad3i9rj8tb1s0" --project StockMarketSolution
            */
        }



        public Dictionary<string, object>? GetStockPriceQuote(string stockSymbol)
        {
            // http client
            HttpClient httpClient = new HttpClient();

            // create request
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}") //URI includes the secret token
            };

            // send request
            HttpResponseMessage httpResponseMessage = httpClient.Send(httpRequestMessage);

            // read the response 

            string responseBody = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();

            // convert response from json to dictionary
            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(responseBody);


            if (responseDictionary == null)
                throw new InvalidOperationException("No response from server");

            if (responseDictionary.ContainsKey("error"))
                throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));

            //return response dictionary back to the caller
            return responseDictionary;
        }
    }
}
