using TheUncodedOne.Game;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Players;
using TheUncodedOne.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TheUncodedOne.Game.Actions;
using System.Reflection;

AssemblyLoader assemblyLoader = new AssemblyLoader();
assemblyLoader.Load();
Game game = new Game();
game.Run();
