using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Attacks;

public class UnravelingAttack : IAttack
{
	private readonly Random _random = new Random();
	public string Name => "UNRAVELING";
	public AttackData Create() => new AttackData(_random.Next(3));
}
