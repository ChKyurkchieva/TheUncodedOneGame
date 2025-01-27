namespace TheUncodedOne.Contract.Interfaces;

public interface IAttackFactory
{
	IAttack CreateAttack(AttackType attackType);
}
public enum AttackType { BoneCrunch, Punch, Unraveling };