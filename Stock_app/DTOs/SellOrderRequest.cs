
using Stock_app.CustomPropertyValidation;
using Stock_app.Models;
using System.ComponentModel.DataAnnotations;

namespace Stock_app.DTOs
{
    public class SellOrderRequest : IValidatableObject
    {
        [Required(ErrorMessage = "Stock Symbol can't be null or empty")]
        public string StockSymbol { get; set; }

        [Required(ErrorMessage = "Stock Name can't be null or empty")]
        public string StockName { get; set; }

        [MinDateVerficationCheck("2000-01-01")]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1,100000, ErrorMessage = "Value should be between 1 and 100000")]
        public uint Quantity { get; set; }


        [Range(1, 10000, ErrorMessage = "Value should be between 1 and 10000")]
        public double Price { get; set; }


        public SellOrder ToSellOrder()
        {
            //create new object of SellOrder class
            return new SellOrder() { StockSymbol = StockSymbol, StockName = StockName, Price = Price, DateAndTimeOfOrder = DateAndTimeOfOrder, Quantity = Quantity };
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            //Date of order should be less than Jan 01, 2000
            if (DateAndTimeOfOrder < Convert.ToDateTime("2000-01-01"))
            {
                results.Add(new ValidationResult("Date of the order should not be older than Jan 01, 2000."));
            }

            return results;
        }

    }
}

