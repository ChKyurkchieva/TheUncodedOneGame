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

public class HumanoidPlayer : IPlayer
{
	private IDisplay _display;
	public HumanoidPlayer(IDisplay display) => _display = display;
	public IAction ChooseAction(IBattle battle, ICharacter character, int typeAction)
	{
		Thread.Sleep(1000);
		IAction action = (typeAction == 0 ) ? new AttackAction(character.DefaultAttack, _display) : new DoNothingAction();
		return action;
	}
}
