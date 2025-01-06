using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;
using TheUncodedOneGame.Characters;

namespace TheUncodedOneGame.Actions;

public class DoNothingAction : IAction
{
    public void Run(IBattle battle, ICharacter character) => Console.WriteLine($"{character.Name} did NOTHING...");
}
