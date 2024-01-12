using System.ComponentModel.DataAnnotations;

namespace Mike_Rogers_CDEV_FP.Models
{
    public class Candles_EnsureCorrectTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var candles = validationContext.ObjectInstance as Candles;

            if (candles != null)
            {
                if (candles.Type.Equals("jar", StringComparison.OrdinalIgnoreCase) || candles.Type.Equals("pillar", StringComparison.OrdinalIgnoreCase))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Type must either be \"Jar\" or \"Pillar\"");
        }
    }
}
