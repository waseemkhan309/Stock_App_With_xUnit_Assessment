

 using System.ComponentModel.DataAnnotations;

namespace Stock_app.Services.Helpers
{
    public class ValidationHelper
    {
        /// <summary>
        /// Persons model validations using ValidationContext and throws ArgumentException in case of any validation errors
        /// </summary>
        /// <param name="obj">Model object to validate</param>
        /// <exception cref="ArgumentException">When one or more validation errors found</exception>
        public static void ModelValidation(object obj)
        {
            //Model validations
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            //validate the model object and get errors
            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            if (!isValid)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
