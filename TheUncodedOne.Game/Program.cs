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
using Microsoft.VisualBasic;

BuildServicesBootstrapper services = new BuildServicesBootstrapper();
services.RegisterServices(services.Services);
var actionTypes = services.ImplementationTypes<IAction>();
for(int i = 0; i < actionTypes.Count; i++)
{
	actionTypes[i] = actionTypes[i].Substring(0, actionTypes[i].Length - "Action".Length);
}
services.Services.AddSingleton(actionTypes);
var actionsImplementation = services.Services.Where(x => x.ServiceType == typeof(IAction)).Select(x => x.ImplementationType).ToList();
var serviceProvider = services.Services.BuildServiceProvider();
var game = serviceProvider.GetRequiredService<Game>();
game.Run();
