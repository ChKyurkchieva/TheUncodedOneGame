using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Displays;

public class ConsoleDisplay : IDisplay
{
	public ConsoleDisplay()
	{
		
	}

	public void DisplayText(string text, ConsoleColor color = ConsoleColor.White)
	{
		System.ConsoleColor consoleColor = Enum.Parse<System.ConsoleColor>(color.ToString());

		System.ConsoleColor old = Console.ForegroundColor;
		Console.ForegroundColor = consoleColor;
		Console.Write(text);
		Console.ForegroundColor = old;
	}
	public void DisplayClear() => Console.Clear();
}
