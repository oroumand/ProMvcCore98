using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Session13.ControllersAndActions.Infrastructures
{
    public class UploadSizeLimitModelValidator : Attribute, IModelValidator
    {
        /// <summary>
        /// ThresholdSize In KB
        /// </summary>
        public long? MaxSize { get; set; } = 300;
        public string Extensions { get; set; } = ".jpg .jpeg";
        public string ErrorMessage { get; set; }

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            IFormFile file = context.Model as IFormFile;
            var result = new List<ModelValidationResult>();
            if (file != null && MaxSize.HasValue)
            {
                if (file.Length > MaxSize * 1024)
                {
                    result.Add(new ModelValidationResult("MaxSize", ErrorMessage));
                }

                if (!Extensions.Split(" ").Any(f => file.FileName.EndsWith(f)))
                {
                    result.Add(new ModelValidationResult("Extensions", $"پسوند فایل ارسالی مجاز نمی‌باشد. {Extensions}"));
                }
            }

            return result;

        }
    }
}
