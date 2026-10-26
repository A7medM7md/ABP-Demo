using Volo.Abp.Modularity;

namespace ABP.Demo1;

[DependsOn(
    typeof(Demo1ApplicationModule),
    typeof(Demo1DomainTestModule)
)]
public class Demo1ApplicationTestModule : AbpModule
{

}
