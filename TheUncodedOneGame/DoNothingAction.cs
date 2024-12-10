using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public class DoNothingAction : IAction
{
	public void Run(Battle battle, Character character) => Console.WriteLine($"{character.Name} did NOTHING...");
}
