using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Xml.Serialization;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Attacks;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Game.Factories;
using TheUncodedOne.Game.Inputs;
using TheUncodedOne.Game.Players;
namespace TheUncodedOne.Game;

internal class BuildServicesBootstrapper : IBootstrapper 
{
	public IServiceCollection Services { get; init; }
	public BuildServicesBootstrapper()
	{
		Services = new ServiceCollection();
		Services.AddSingleton<IDisplay, ConsoleDisplay>();
		Services.AddSingleton<IInput, ConsoleInput>();
		Services.AddSingleton<IActionFactory, ActionFactory>();
		Services.AddTransient<ICharacter, Skeleton>();
		Services.AddTransient<ICharacter, TheUncodedOneCharacter>();
		Services.AddTransient<ICharacter, TrueProgrammer>();
		Services.AddTransient<IAttack, BoneCrunchAttack>();
		Services.AddTransient<IAttack, PunchAttack>();
		Services.AddTransient<IAttack, UnravelingAttack>();
		Services.AddTransient<IAction, AttackAction>();
		Services.AddTransient<IAction, DoNothingAction>();
		Services.AddTransient<IPlayer, ComputerPlayer>();
		Services.AddTransient<IPlayer, HumanoidPlayer>();
		Services.AddSingleton<IAttackFactory, AttackFactory>();
		Services.AddTransient<List<IAction>>();
		Services.AddSingleton<Game>();
		
	}

	public IServiceCollection RegisterServices(IServiceCollection serviceCollection)
	{
		AssemblyLoader loadAssemblies = new AssemblyLoader();
		List<IBootstrapper> bootstrappers = loadAssemblies.Load();
		foreach (IBootstrapper boot in bootstrappers)
		{
			boot.RegisterServices(serviceCollection);
		}

		return serviceCollection;
	}

	public List<string> ImplementationTypes<T>()
	{
		List<string> result = new List<string>();
		Services.Where(x => x.ServiceType == typeof(T)).Select(x => x.ImplementationType).ToList().ForEach(a => result.Add(a.Name));
		return result;
	}
}
