using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game;

public class NullInventory : IInventory
{
	public List<IItem> Items { get; set; }
	public NullInventory()
	{
		Items = null;
	}
	public void RemoveItem(IItem item)
	{
		throw new NotImplementedException();
	}
}
