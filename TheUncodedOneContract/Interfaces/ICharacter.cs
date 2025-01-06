using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneContract.Interfaces;

public interface ICharacter
{
    public abstract string Name { get; }
    public abstract IAttack DefaultAttack { get; }
	public int MaxHP { get; }
	public int HP { get; set; }
}