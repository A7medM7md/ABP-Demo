using Volo.Abp;

namespace ABP.Demo1.Exceptions
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(int id) : base(Demo1DomainErrorCodes.PRODUCT_NOT_FOUND)
        {
            WithData("id", id);
        }
    }
}
