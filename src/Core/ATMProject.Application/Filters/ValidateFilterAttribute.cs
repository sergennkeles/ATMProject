using ATMProject.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ATMProject.Application.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        override public void OnActionExecuting(ActionExecutingContext context)
        {
            // ModelState EfCore'da bulunan bir property sayesinde validasyon hatalarını kontrol edebiliyoruz. FluentValidation kullanmasak bile.
            // FluentValidation kullanırsak da validasyon hataları otomatik olarak ModelState'e ekleniyor.
            if (!context.ModelState.IsValid) //
            {
                // ModelState'e eklenen hataların listesini almak için SelectMany ile Hataları alıyoruz. Daha sonra bu hataların mesajlarını almak için Select kullanarak ErrorMessage'ı alıyoruz ve listeye çeviriyoruz
                var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                foreach (var error in errors)
                {

                context.Result = new BadRequestObjectResult(new ValidationException(error));
                }
            }
        }
    }
}
