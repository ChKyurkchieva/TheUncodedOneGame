using ITheUncodedOne.Inventory.Actions;
using Microsoft.Extensions.DependencyInjection;
using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Inventory;

public class InventoryBootstrapper : IBootstrapper
{
	public IServiceCollection RegisterServices(IServiceCollection serviceCollection)
	{
		serviceCollection.AddTransient<IItem, HealthPotionItem>();
		serviceCollection.AddTransient<IAction, UseItemAction>();
		return serviceCollection;
	}
}
