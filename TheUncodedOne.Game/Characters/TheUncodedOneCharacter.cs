using System;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Attacks;

namespace TheUncodedOne.Game.Characters;

public class TheUncodedOneCharacter : ICharacter
{
	private int _hp;
	public string Name => "THE UNCODED ONE";
	public IAttack DefaultAttack { get; } = new UnravelingAttack();
	public int MaxHP { get; }
	public int HP {get => _hp; set => _hp = Math.Clamp(_hp, 0, MaxHP);}
	public TheUncodedOneCharacter() => HP = MaxHP = 15;
}
