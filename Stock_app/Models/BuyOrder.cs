
using System.Formats.Asn1;

namespace Stock_app.Models
{
    public class BuyOrder
    {
        public Guid BuyOrderId { get; set; }
        public string BuyStockName { get; set; }
        public string BuyStockSymbol { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
