using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame.Attacks;

public class UnravelingAttack : IAttack
{
	private Random _random = new Random();
	public string Name => "UNRAVELING";
	public AttackData Create() => new AttackData(_random.Next(3));
}
