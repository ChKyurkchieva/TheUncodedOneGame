using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;
using TheUncodedOneGame.Actions;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;

namespace TheUncodedOneGame.Players;

public class ComputerPlayer : IPlayer
{
    private IDisplay _display;
    public ComputerPlayer(IDisplay display) => _display = display;
    public IAction ChooseAction(IBattle battle, ICharacter character, int typeAction = 0)
    {
        Thread.Sleep(500);
        IAction action = (typeAction == 0) ? new AttackAction(character.DefaultAttack, _display) : new DoNothingAction();
        return action;
    }
}
