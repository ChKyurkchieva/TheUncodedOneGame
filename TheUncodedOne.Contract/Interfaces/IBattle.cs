namespace TheUncodedOne.Contract.Interfaces;

public interface IBattle
{
	public IParty GetEnemyPartyFor(ICharacter character);
}
