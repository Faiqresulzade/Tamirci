using Tamirci.Services.Contracts;
using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services.Buisness
{
    public class ProductService : IProductService
    {
        private readonly IServiceManager serviceManager;

        public ProductService(IServiceManager serviceManager)
        {
            Task.WhenAll();
            this.serviceManager = serviceManager;
            //io bound , cpu bound
            //5
            //3
        }

        public async Task Create()
        {
            var a = Task.Delay(1000);
            var b = Task.Delay(2000);

            await Task.WhenAll(a, b);
            //serviceManager.CraftsmanService
            throw new NotImplementedException();
        }
    }
}
