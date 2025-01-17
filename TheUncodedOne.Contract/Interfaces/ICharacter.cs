namespace TheUncodedOne.Contract.Interfaces;

public interface ICharacter
{
    public string Name { get; }
    public IAttack DefaultAttack { get; }
	public int MaxHP { get; }
	public int HP { get; set; }
}