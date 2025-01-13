namespace TheUncodedOne.Contract.Interfaces;
public record AttackData(int Damage);
public interface IAttack
{
    string Name { get; }
    AttackData Create();
}
