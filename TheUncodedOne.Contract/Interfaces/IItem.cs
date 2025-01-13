namespace TheUncodedOne.Contract.Interfaces;

public record ItemData(int Points);
public interface IItem
{
	string Name { get; }
	ItemData Create();
}
