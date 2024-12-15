using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame.Displays;

public interface IDisplay
{
	void DisplayClear();
	void DisplayText(string text, ConsoleColor color = ConsoleColor.White);
}
