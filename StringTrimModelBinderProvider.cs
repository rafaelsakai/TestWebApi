using Microsoft.AspNetCore.Mvc.ModelBinding;

public class StringTrimModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));


        if (context.Metadata.ModelType == typeof(string) && context.BindingInfo.BindingSource!=BindingSource.Body)
            return new StringTrimModelBinder();

        return null;
    }
}