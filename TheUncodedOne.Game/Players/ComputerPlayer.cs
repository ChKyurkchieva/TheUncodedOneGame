using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;

namespace TheUncodedOne.Game.Players;

public class ComputerPlayer : IPlayer
{
    private IDisplay _display;
    public ComputerPlayer(IDisplay display) => _display = display;
    public IAction ChooseAction(IBattle battle, ICharacter character, int typeAction = 0)
    {
        Thread.Sleep(500);
        IAction action = (typeAction == 0) ? new AttackAction(character.DefaultAttack, _display) : new DoNothingAction(_display);
        return action;
    }
}
