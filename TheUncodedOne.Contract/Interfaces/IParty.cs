namespace TheUncodedOne.Contract.Interfaces;

public interface IParty
{
	public IPlayer Player { get; }
	public List<ICharacter> Characters { get; }
	public IDisplay Display { get; init; }
}
