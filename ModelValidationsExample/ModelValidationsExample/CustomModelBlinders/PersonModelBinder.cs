using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.CustomModelBlinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
           Person person = new Person();

            var FirstName = bindingContext.ValueProvider.GetValue("FirstName");
           if (FirstName.Count() > 0)
            {
                person.Name = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

            }

            var LastName = bindingContext.ValueProvider.GetValue("LastName");

            if (LastName.Count() > 0)
            {
                person.Name += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;

        }
    }
}
