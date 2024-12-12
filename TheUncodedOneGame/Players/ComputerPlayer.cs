using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Actions;
using TheUncodedOneGame.Characters;

namespace TheUncodedOneGame.Players;

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Battle battle, Character character)
    {
        Thread.Sleep(500);
        return new AttackAction(character.DefaultAttack);
    }
}
