using Tamirci.Services.Contracts.Buisness;

namespace Tamirci.Services.Contracts;

public interface IServiceManager
{
    public ICraftsmanService CraftsmanService { get; }
}
