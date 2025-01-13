namespace TheUncodedOne.Contract.Interfaces;

public interface IDisplay
{
	void DisplayClear();
	void DisplayText(string text, ConsoleColor color = ConsoleColor.White);
}
