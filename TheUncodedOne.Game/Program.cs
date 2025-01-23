using TheUncodedOne.Game;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Players;
using TheUncodedOne.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Displays;
using System.Reflection;
using TheUncodedOne.Game.Inputs;
using TheUncodedOne.Game.Attacks;
using TheUncodedOne.Game.Factories;

BuildServicesBootstrapper services = new BuildServicesBootstrapper();
services.RegisterServices(services.Services);
var actionTypes = services.ImplementationTypes<IAction>();
services.Services.AddSingleton(actionTypes);
// List of actions
var actionsImplementation = services.Services.Where(x => x.ServiceType == typeof(IAction)).Select(x => x.ImplementationType).ToList();
//services.Services.AddSingleton(actionsImplementation);
var serviceProvider = services.Services.BuildServiceProvider();
var game = serviceProvider.GetRequiredService<Game>();
game.Run();

//public void DisplayActions(IServiceProvider provider)
//{
//	var display = provider.GetRequiredService<IDisplay>();
//	var actions = provider.GetRequiredService<IEnumerable<IAction>>().ToList();
//	actions.ForEach(x => display.DisplayText(x.ToString()));
//}