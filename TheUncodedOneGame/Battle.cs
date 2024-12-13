using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;

namespace TheUncodedOneGame;

public class Battle
{
	private Party Heroes;
	private Party Monsters;
	private IDisplay _display;
	internal Party GetEnemyPartyFor(Character character)
	{
		return Heroes.Characters.Contains(character) ? Monsters : Heroes;
	}

	public Battle(Party heroes, Party monsters, IDisplay display)
	{
		Heroes = heroes;
		Monsters = monsters;
		_display = display; 
	}

	int HasWinner()
	{
		if (Heroes.Characters.Count == 0)
		{
			_display.DisplayText("\nYou are defeated. The Uncoded One’s forces have prevailed.\n", ConsoleColor.Red);
			return 0;
		}
		if (Monsters.Characters.Count == 0)
		{
			_display.DisplayText("\nYou win this battle!\n\n", ConsoleColor.Green);
			return 1;
		}
		return -1;
	}
	public int Run()
	{
		Process();
		return HasWinner();
	}

	private void Process()
	{
		while (true)
		{
			IEnumerable<(Party party, Character character)> partyCharacters = new Party[] { Heroes, Monsters }
				.SelectMany(party => party.Characters.Select(character => (party, character)));
			foreach ((Party party, Character character) in partyCharacters)
			{
				_display.DisplayText($"It is {character.Name}'s turn...\n");
				Thread.Sleep(500);
				party.Player.ChooseAction(this, character).Run(this, character);
				Party enemy = GetEnemyPartyFor(character);
				enemy.Characters.Where(ch => ch.HP == 0).ToList().ForEach(enemy.Remove);
				_display.DisplayText("\n");
				if (Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0)
					return;
			}
		}
	}
}
