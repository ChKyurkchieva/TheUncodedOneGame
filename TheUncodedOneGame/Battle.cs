using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;

namespace TheUncodedOneGame;

public class Battle
{
	private Party Heroes;
	private Party Monsters;

	internal Party GetEnemyPartyFor(Character character)
	{
		return Heroes.Characters.Contains(character) ? Monsters : Heroes;
	}

	public Battle(Party heroes, Party monsters)
	{
		Heroes = heroes;
		Monsters = monsters;
	}

	int HasWinner()
	{
		if (Heroes.Characters.Count == 0)
		{
			Console.WriteLine("You are defeated. The Uncoded One’s forces have prevailed.");
			return 0;
		}
		if (Monsters.Characters.Count == 0)
		{
			Console.WriteLine("You win this battle!");
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
				Console.WriteLine($"It is {character.Name}'s turn...");
				Thread.Sleep(500);
				party.Player.ChooseAction(this, character).Run(this, character);
				Party enemy = GetEnemyPartyFor(character);
				enemy.Characters.Where(ch => ch.HP == 0).ToList().ForEach(enemy.Remove);
				Console.WriteLine();
				if (Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0)
					return;
			}
		}
	}
}
