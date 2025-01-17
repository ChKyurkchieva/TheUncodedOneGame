using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game.Inputs;

public class ConsoleInput : IInput
{
	public string? ReadLine()
	{
		string? result = Console.ReadLine();
		return result;
	}
}
