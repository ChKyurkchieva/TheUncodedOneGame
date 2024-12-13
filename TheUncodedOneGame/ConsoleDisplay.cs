using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public static class ConsoleDisplay 
{
	public static void DisplayText(string text, ConsoleColor color = ConsoleColor.White)
	{
		ConsoleColor old = Console.ForegroundColor;
		Console.ForegroundColor = color;
		Console.Write(text);
		Console.ForegroundColor = old;
	}
}
