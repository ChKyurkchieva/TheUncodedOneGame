using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Players;

namespace TheUncodedOneGame;

public class Party
{
	public IPlayer Player { get; }
	public List<Character> Characters { get; } = new List<Character>();
	public Party(IPlayer player) => Player = player;
	public void Remove(Character character)
	{
		if (Characters.Remove(character))
			Console.WriteLine($"{character.Name} has been removed successfully!");
	}
}
