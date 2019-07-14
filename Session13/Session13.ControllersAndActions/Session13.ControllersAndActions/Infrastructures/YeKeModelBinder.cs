using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace Session13.ControllersAndActions.Infrastructures
{
    internal class YeKeModelBinder : IModelBinder
    {
        private readonly IModelBinder modelBinder;

        public YeKeModelBinder(IModelBinder modelBinder)
        {
            this.modelBinder = modelBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new System.ArgumentNullException(nameof(bindingContext));
            }

            var valueOfModel = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueOfModel != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueOfModel);

                var valueAsString = valueOfModel.FirstValue;
                if (string.IsNullOrWhiteSpace(valueAsString))
                {
                    return modelBinder.BindModelAsync(bindingContext);
                }

                var model = valueAsString.Replace((char)1610, (char)1740).Replace((char)1603, (char)1705);
                bindingContext.Result = ModelBindingResult.Success(model);
                return Task.CompletedTask;
            }

            return modelBinder.BindModelAsync(bindingContext);
        }
    }
}