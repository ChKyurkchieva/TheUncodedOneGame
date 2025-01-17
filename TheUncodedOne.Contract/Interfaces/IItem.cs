namespace TheUncodedOne.Contract.Interfaces;

public interface IItem
{
	string Name { get; }
	ItemData Create();
}
