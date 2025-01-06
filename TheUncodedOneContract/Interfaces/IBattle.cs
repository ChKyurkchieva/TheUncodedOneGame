using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneContract.Interfaces;

public interface IBattle
{
	public IParty GetEnemyPartyFor(ICharacter character);
}
