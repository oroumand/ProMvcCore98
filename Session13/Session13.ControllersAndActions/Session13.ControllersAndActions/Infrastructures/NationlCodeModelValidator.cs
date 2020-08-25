using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions.Infrastructures
{

    public class NationlCodeModelValidator : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; } = "کد ملی وارد شده صحیح نمی‌باشد.";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            string input = context.Model as string;

            var result = new List<ModelValidationResult>();

            input = input.PadLeft(10, '0');
            if (!Regex.IsMatch(input, @"^\d{10}$"))
                result.Add(new ModelValidationResult("NationalCode", ErrorMessage));

            return result;
        }
    }
}
