using TheUncodedOne.Game;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Players;
using TheUncodedOne.Contract.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TheUncodedOne.Game.Actions;
using System.Reflection;

//Assembly assembly = Assembly.LoadFrom("TheUncodedOne.Inventory.dll");

//Type[] type = assembly.GetTypes();
//foreach (Type t in type)
//{
//	var obj = Activator.CreateInstance(t);
//	Console.WriteLine(obj);
//}
Game game = new Game();
game.Run();
