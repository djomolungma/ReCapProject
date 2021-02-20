using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConserns.Validation
{
    //CrossCuttingConserns
    //1.Transaction
    //2.Validation
    //3.Catching
    //4.Authorization
    //5.Logging
    //6.Performance
    public class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
