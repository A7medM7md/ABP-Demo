using System.Linq;
using Volo.Abp.Application.Services;
using Volo.Abp.Validation;

namespace ABP.Demo1.Bases
{
    //[Authorize] //=> This Makes All Services Inherits From AppService Is Authorized
    // This Service must be abstract, because you will never create an instance of it, but you will inherit from it.
    // and also prevent proxy generation from it, because it will never be used as a service, but only as a base for other services.
    public abstract class BaseAppService : ApplicationService
    {
        // You can put here anything common between services

        public BaseAppService()
        {
        }

        internal AbpValidationException GetValidationException(FluentValidation.Results.ValidationResult res)
        {
            var message = string.Join(", ", res.Errors.Select(x => x.ErrorMessage));

            var errors =
                res
                .Errors
                .Select(x => new System.ComponentModel.DataAnnotations.ValidationResult(x.ErrorMessage, [x.PropertyName]))
                .ToList();

            return new AbpValidationException(message, errors);
        }
    }
}
