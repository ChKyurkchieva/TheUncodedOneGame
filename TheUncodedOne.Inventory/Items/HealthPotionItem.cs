using TheUncodedOne.Contract.Interfaces;

namespace ITheUncodedOne.Inventory.Actions;

public class HealthPotionItem : IItem
{
	private readonly int _healthPoints = 10;
	public string Name => "Health potion";
	public ItemData Create() => new(_healthPoints);
	public HealthPotionItem() { }
}
