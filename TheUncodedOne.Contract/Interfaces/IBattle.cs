using TheUncodedOne.Contract;
namespace TheUncodedOne.Contract.Interfaces;
public interface IBattle
{
	public IParty GetEnemyPartyFor(ICharacter character);
	public BattleMode GetMode();
}
public enum BattleMode { HumanVsHuman = 1, HumanVsComputer, ComputerVsComputer }