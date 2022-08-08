using Microsoft.AspNetCore.Mvc.ModelBinding;

public class StringTrimModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext is null)
            throw new ArgumentNullException(nameof(bindingContext));

        var modelName = bindingContext.ModelName;
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

        if (valueProviderResult == ValueProviderResult.None)
            return Task.CompletedTask;

        bindingContext.Result = ModelBindingResult.Success(valueProviderResult.FirstValue.Trim());
        return Task.CompletedTask;
    }
}