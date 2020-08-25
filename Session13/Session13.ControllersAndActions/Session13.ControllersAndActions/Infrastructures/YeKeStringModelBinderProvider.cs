using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Session13.ControllersAndActions.Infrastructures
{
    public class YeKeStringModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType)
            {
                return null;
            }

            var modelBinder = new SimpleTypeModelBinder(context.Metadata.ModelType);

            if (context.Metadata.ModelType == typeof(string))
            {
                return new YeKeModelBinder(modelBinder);
            }

            return modelBinder;
        }
    }
}
