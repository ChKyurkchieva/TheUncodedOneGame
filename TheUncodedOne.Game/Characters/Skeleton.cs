using System;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Attacks;

namespace TheUncodedOne.Game.Characters;

public class Skeleton : ICharacter
{
	private int _hp;
    public string Name => "SKELETON";
	public IAttack DefaultAttack { get; } = new BoneCrunchAttack();
	public int MaxHP { get; }
	public int HP { get => _hp; set => _hp = Math.Clamp(value, 0, MaxHP); }
	public Skeleton() => HP = MaxHP = 5;
}
