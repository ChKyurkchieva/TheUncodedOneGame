using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneContract.Interfaces;

public interface IParty
{
	public IPlayer Player { get; }
	public List<ICharacter> Characters { get; }
	public IDisplay Display { get; init; }
}
