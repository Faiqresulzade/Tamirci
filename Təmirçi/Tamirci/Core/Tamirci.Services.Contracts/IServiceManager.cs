using Tamirci.Services.Contracts.Buisness;
using Tamirci.Services.Contracts.Factories;

namespace Tamirci.Services.Contracts;

public interface IServiceManager
{
    public ICraftsmanService CraftsmanService { get; }
    public ICraftsmanFactory UserFactory { get; }
}
