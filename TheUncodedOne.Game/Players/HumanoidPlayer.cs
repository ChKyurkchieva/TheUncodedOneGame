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
	public IAction ChooseAction(IBattle battle, ICharacter character, string typeAction)
	{
		Thread.Sleep(1000);
		IAction action = _actions.Find(x => x.ToString().Contains(typeAction)) ?? throw new NullReferenceException($"There is no such type action as {typeAction}");
		return action;
	}
}
