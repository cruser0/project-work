using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity_Validator
{
    public class ValidatorEntity
    {
        public static List<ValidationResult> Validate<T>(T entity)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(entity);

            Validator.TryValidateObject(entity, context, results, true);

            return results;
        }
    }
}