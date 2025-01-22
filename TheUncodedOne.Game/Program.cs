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

BuildServicesBootstrapper services = new BuildServicesBootstrapper();
services.RegisterServices(services.Services);
var serviceProvider = services.Services.BuildServiceProvider();

var game = serviceProvider.GetRequiredService<Game>();
game.Run();
