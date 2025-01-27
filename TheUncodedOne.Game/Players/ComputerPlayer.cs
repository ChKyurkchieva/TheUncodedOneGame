using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;

namespace TheUncodedOne.Game.Players;

public class ComputerPlayer : IPlayer
{
    private IDisplay _display;
    private List<IAction> _actions;
    public ComputerPlayer(IDisplay display) => _display = display;
	public ComputerPlayer(IDisplay display, List<IAction> actions)
	{
		_display = display;
        _actions = actions;
	}

	public IAction ChooseAction(IBattle battle, ICharacter character, IActionFactory actionFactory, string actionType = "Attack")
    {
        Thread.Sleep(500);
        return actionFactory.CreateAction(actionType);
    }
}
