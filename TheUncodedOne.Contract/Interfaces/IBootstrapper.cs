using Microsoft.Extensions.DependencyInjection;
namespace TheUncodedOne.Contract.Interfaces;

public interface IBootstrapper
{
	public IServiceCollection RegisterServices(IServiceCollection serviceCollection);
}
