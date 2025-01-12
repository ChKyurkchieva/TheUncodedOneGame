using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneContract.Interfaces;

public record ItemData(int Points);
public interface IItem
{
	string Name { get; }
	ItemData Create();
}
