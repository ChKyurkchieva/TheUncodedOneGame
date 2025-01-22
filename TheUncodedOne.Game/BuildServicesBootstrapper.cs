using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Xml.Serialization;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Attacks;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Game.Inputs;
using TheUncodedOne.Game.Players;
namespace TheUncodedOne.Game;

internal class BuildServicesBootstrapper : IBootstrapper 
{
	public IServiceCollection Services { get; init; }
	public BuildServicesBootstrapper()
	{
		Services = new ServiceCollection();
		Services.AddSingleton<ConsoleDisplay>();
		Services.AddSingleton<ConsoleInput>();
		Services.AddTransient<Skeleton>();
		Services.AddTransient<TheUncodedOneCharacter>();
		Services.AddTransient<TrueProgrammer>();
		Services.AddSingleton<BoneCrunchAttack>();
		Services.AddSingleton<PunchAttack>();
		Services.AddSingleton<UnravelingAttack>();
		Services.AddSingleton<AttackAction>();
		Services.AddSingleton<DoNothingAction>();
		Services.AddTransient<ComputerPlayer>();
		Services.AddTransient<HumanoidPlayer>();
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
}
