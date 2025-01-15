using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Game.Players;

namespace TheUncodedOne.Game;

public class Party : IParty
{
	public IPlayer Player { get; }
	public List<ICharacter> Characters { get; } = new List<ICharacter>();
	private IDisplay _display;
	public IDisplay Display { get; init; }
	public Party(IPlayer player, IDisplay display)
	{
		_display = display;
		Player = player;
		Display = _display;
	}

	public void Remove(ICharacter character)
	{
		if (Characters.Remove(character))
			_display.DisplayText($"\n{character.Name} has been removed successfully!\n", ConsoleColor.Yellow);
	}
}
