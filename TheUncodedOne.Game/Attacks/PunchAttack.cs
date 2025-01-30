using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Attacks;

public class PunchAttack : IAttack
{
    public string Name => "Punch";
    public AttackData Create() => new AttackData(1);
}
