using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;

namespace Inventory.Items;

public class HealthPotionItem : IItem
{
	private readonly int _healthPoints = 10;
	public string Name => "Health potion";
	public ItemData Create() => new(_healthPoints);
}
