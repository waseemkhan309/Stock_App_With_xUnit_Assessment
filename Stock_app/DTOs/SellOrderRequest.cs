using Stock_app.CustomPropertyValidation;
using System.ComponentModel.DataAnnotations;

namespace Stock_app.DTOs
{
    public class SellOrderRequest
    {
        [Required]
        public string StockSymbol { get; set; }

        [Required]
        public string StockName { get; set; }

        [MinDateVerficationCheck("2000-01-01")]
        public DateTime DateAndTimeOfDate { get; set; }

        [Range(1,100000, ErrorMessage = "Value should be between 1 and 100000")]
        public uint Quantity { get; set; }


        [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
        public double Price { get; set; }
    }
}
