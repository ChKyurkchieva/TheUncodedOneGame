using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public class Party
{
	public IPlayer Player { get; }
	public List<Character> Characters { get; } = new List<Character>();
	public Party(IPlayer player) => Player = player;
}
