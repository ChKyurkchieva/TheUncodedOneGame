using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;
public abstract class Character
{
	public abstract string Name { get; }
	public abstract IAttack DefaultAttack { get; }
}