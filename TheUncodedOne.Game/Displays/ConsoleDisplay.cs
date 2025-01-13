using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Displays;

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
