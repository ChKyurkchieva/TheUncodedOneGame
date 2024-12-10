using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public interface IPlayer
{
	IAction ChooseAction(Battle battle, Character character);
}
