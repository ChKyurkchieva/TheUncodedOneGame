using System;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;

namespace TheUncodedOne.Game.Players;

public class HumanoidPlayer : IPlayer
{
	private IDisplay _display;
	private List<IAction> _actions;
	public HumanoidPlayer(IDisplay display) => _display = display;
	public HumanoidPlayer(IDisplay display, List<IAction> actions)
	{
		_display = display;
		_actions = actions;
	}
	public IAction ChooseAction(IBattle battle, ICharacter character, IActionFactory actionFactory, string typeAction)
	{
		Thread.Sleep(1000);
		return actionFactory.CreateAction(typeAction);
	}
}
