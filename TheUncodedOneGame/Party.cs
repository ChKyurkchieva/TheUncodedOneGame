using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;
using TheUncodedOneGame.Players;

namespace TheUncodedOneGame;

public class Party : IParty
{
	public IPlayer Player { get; }
	public List<ICharacter> Characters { get; } = new List<ICharacter>();
	private IDisplay _display;
	public IDisplay Display { get ; init; }
	public Party(IPlayer player, IDisplay display)
	{
		_display = display;
		Player = player;
	}

	public void Remove(ICharacter character)
	{
		if (Characters.Remove(character))
			_display.DisplayText($"\n{character.Name} has been removed successfully!\n", ConsoleColor.Yellow);
	}
}
