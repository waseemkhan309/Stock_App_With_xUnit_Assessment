
using System.ComponentModel.DataAnnotations;

namespace Stock_app.CustomPropertyValidation
{
    public class MinDateVerficationCheck : ValidationAttribute
    {
        private readonly DateTime _minDate;


        // Constructor with custom minimum date
        public MinDateVerficationCheck(string minDate)
        {
            _minDate = DateTime.Parse(minDate);
        }


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            if (value == null)
            {
                return ValidationResult.Success; // or return new ValidationResult("Date is required");
            }

            if (value is not DateTime dateAndTimeOfOrder)
            {
                return new ValidationResult("Invalid date format");
            }


            DateTime DateAndTimeOfOrder = (DateTime)value;


            if(DateAndTimeOfOrder.Date < _minDate)
            {
                return new ValidationResult(ErrorMessage ?? $"The date cannot be older than {_minDate:dd-MM-yyyy}");
            }

            return ValidationResult.Success;
        }
    }
}
