
using System.ComponentModel.DataAnnotations;


namespace Stock_app.Models
{
    public class BuyOrder
    {
        [Key]
        public Guid BuyOrderId { get; set; }
        [Required(ErrorMessage ="Stock Name can't be null")]
        public string StockName { get; set; }
        public string StockSymbol { get; set; }
                
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 10000, ErrorMessage = "The maximum price of stock is 10000. Minimum is 1.")]
        public double Price { get; set; }

        [Range(1, 100000, ErrorMessage = "You can buy maximum of 100000 shares in single order. Minimum is 1.")]
        public uint Quantity { get; set; }
    }
}
