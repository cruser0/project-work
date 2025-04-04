using System.ComponentModel.DataAnnotations;
namespace Entity_Validator.CustomAttributes
{

    public class AmountPaidRangeAttribute : ValidationAttribute
    {
        private readonly string _invoiceAmountProperty;
        public AmountPaidRangeAttribute(string invoiceAmountProperty)
        {
            _invoiceAmountProperty = invoiceAmountProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var invoiceProperty = validationContext.ObjectType.GetProperty(_invoiceAmountProperty);
            var invoiceAmount = invoiceProperty.GetValue(validationContext.ObjectInstance, null);
            decimal invoiceAmountValue = (decimal)invoiceAmount;
            if (value is decimal amountPaid && (amountPaid < 0 || amountPaid > invoiceAmountValue))
            {
                return new ValidationResult($"Amount paid must be between 0€ and {invoiceAmountValue}€.");
            }
            return ValidationResult.Success;
        }
    }
}
