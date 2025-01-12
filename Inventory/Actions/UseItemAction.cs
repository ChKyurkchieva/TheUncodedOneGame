using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;

namespace Inventory.Actions;

public class UseItemAction : IAction
{
	private readonly IItem _item;
	private readonly IDisplay _display;

	public UseItemAction(IItem item, IDisplay display)
	{
		_item = item;
		_display = display;
	}

	public void Run(IBattle battle, ICharacter character)
	{
		_display.DisplayText($"{character.Name} was equiped with {_item.Name}");
		IParty party = battle.GetEnemyPartyFor(battle.GetEnemyPartyFor(character).Characters[0]);
		//party.Inventory.Remove(_item);
		ItemData itemData = _item.Create();
		character.HP += itemData.Points;
	}
}
