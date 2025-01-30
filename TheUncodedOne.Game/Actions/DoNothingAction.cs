using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Characters;

namespace TheUncodedOne.Game.Actions;

public class DoNothingAction : IAction
{
    private IDisplay _display;

	public DoNothingAction(IDisplay display) => _display = display;

	public string Name { get; } = "DoNothing";
    public void Run(IBattle battle, ICharacter character) => _display.DisplayText($"{character.Name} did NOTHING...");
}
