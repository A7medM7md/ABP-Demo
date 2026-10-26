using ABP.Demo1.Samples;
using Xunit;

namespace ABP.Demo1.EntityFrameworkCore.Domains;

[Collection(Demo1TestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Demo1EntityFrameworkCoreTestModule>
{

}
