using System.ComponentModel.DataAnnotations;
using Stock_app.CustomPropertyValidation;

namespace Stock_app.DTOs
{
    public class BuyOrderRequest
    {
        [Required(ErrorMessage = "Stock Symbol is required.")]
        public string StockSymbol { get; set; }

        [Required(ErrorMessage ="Stock Name is required.")]
        public string StockName { get; set; }

        [MinDateVerficationCheck("2000-01-01")]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1,100000, ErrorMessage = "Value should be between 1 and 100000")]
        public int Quantity { get; set; }


        [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
        public double Price { get; set; }

    }
}
