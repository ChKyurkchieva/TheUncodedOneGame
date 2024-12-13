using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public interface IDisplay
{
	public void DisplayText(string text, ConsoleColor color = ConsoleColor.White);
}
