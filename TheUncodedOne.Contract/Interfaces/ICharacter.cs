namespace TheUncodedOne.Contract.Interfaces;

public interface ICharacter
{
    public abstract string Name { get; }
    public abstract IAttack DefaultAttack { get; }
	public int MaxHP { get; }
	public int HP { get; set; }
}