using ABP.Demo1.Samples;
using Xunit;

namespace ABP.Demo1.EntityFrameworkCore.Applications;

[Collection(Demo1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Demo1EntityFrameworkCoreTestModule>
{

}
