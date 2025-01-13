using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Attacks;

public class BoneCrunchAttack : IAttack
{
    public string Name => "BONE CRUNCH";
    public AttackData Create() => new AttackData(new Random().Next(2));
}
