using ABP.Demo1.Localization;
using Volo.Abp.Application.Services;

namespace ABP.Demo1;

/* 
 * Inherit your application services from this class.
 */
public abstract class Demo1AppService : ApplicationService
{
    protected Demo1AppService()
    {
        LocalizationResource = typeof(Demo1Resource);
    }
}
