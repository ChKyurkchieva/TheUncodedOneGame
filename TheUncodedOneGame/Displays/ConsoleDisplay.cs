using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;

namespace TheUncodedOneGame.Displays;

public class ConsoleDisplay : IDisplay
{
	public void DisplayText(string text, ConsoleColor color = ConsoleColor.White)
	{
		ConsoleColor old = Console.ForegroundColor;
		Console.ForegroundColor = color;
		Console.Write(text);
		Console.ForegroundColor = old;
	}
	public void DisplayClear() => Console.Clear();
}
