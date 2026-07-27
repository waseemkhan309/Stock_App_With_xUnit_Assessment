

namespace Stock_app.Models
{
    public class SellOrder
    {
        public Guid SellOrderId { get; set; }
        public string SellOrderSymbol { get; set; }
        public string SellOrderName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
