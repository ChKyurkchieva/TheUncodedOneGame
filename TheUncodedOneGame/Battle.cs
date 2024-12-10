using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	public void Run()
	{
		while (true)
		{
			foreach(Party party in new Party[]{Heroes, Monsters})
			{
				foreach (Character character in party.Characters)
				{
					Console.WriteLine($"It is {character.Name}'s turn...");
					Thread.Sleep(500);
					party.Player.ChooseAction(this, character).Run(this, character);
					Console.WriteLine();
				}
			}
		}
	}
}
