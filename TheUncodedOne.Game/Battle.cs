using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game;

public class Battle : IBattle
{
	private Party Heroes { get; init; }
	private Party Monsters { get; init; }
	private readonly IDisplay _display;
	private readonly IInput _input;
	private readonly List<string> _actionTypes;
	private Mode _mode;

	public Mode Mode { get => _mode; set => _mode = value; }
	public IParty GetEnemyPartyFor(ICharacter character)
	{
		return Heroes.Characters.Contains(character) ? Monsters : Heroes;
	}
	public Battle(Party heroes, Party monsters, IDisplay display, IInput input, Mode mode, List<string> actionTypes)
	{
		Heroes = heroes;
		Monsters = monsters;
		_display = display;
		_input = input;
		_mode = mode;
		_actionTypes = actionTypes;
	}
	private int HasWinner()
	{
		if (Heroes.Characters.Count == 0)
		{
			_display.DisplayText("\nYou are defeated. The Uncoded One’s forces have prevailed.\n", ConsoleColor.Red);
			return 0;
		}
		if (Monsters.Characters.Count == 0)
		{
			_display.DisplayText("\nYou win this battle!\n\n", ConsoleColor.Green);
			return 1;
		}
		return -1;
	}
	private string GetTypeAction()
	{
		string? result;
		do
		{
			_display.DisplayText("Choose action:\n", ConsoleColor.Yellow);
			foreach (string s in _actionTypes)
				_display.DisplayText($"\t{s}\n");
			_display.DisplayText("Which action do you choose? ", ConsoleColor.Yellow);
			result = _input.ReadLine();
		}while(result == null && _actionTypes.Any(x => x != result));

		return result;
	}
	private string DefaultTypeAction()
	{
		 return _actionTypes.FirstOrDefault()?.ToString();
	}
	private void BattleModesMove(Party party, ICharacter character, Mode mode)
	{
		if (mode == Mode.HumanVsHuman || (mode == Mode.HumanVsComputer && party == Heroes))
		{
			string actionType = GetTypeAction();
			party.Player.ChooseAction(this, character, actionType).Run(this, character);
			return;
		}
		party.Player.ChooseAction(this, character, DefaultTypeAction()).Run(this, character);
	}
	private void PrintBattleStatus(Party party, Party enemy)
	{
		_display.DisplayText("==================================================BATTLE===============================================================\n");
		foreach (ICharacter ch in party.Characters)
			_display.DisplayText($"{ch.Name}\t\t\t( {ch.HP}/{ch.MaxHP} )\n", ConsoleColor.Yellow);
		_display.DisplayText("----------------------------------------------------VS-----------------------------------------------------------------\n");
		foreach(ICharacter ch in enemy.Characters)
			_display.DisplayText($"{ch.Name}\t\t( {ch.HP}/{ch.MaxHP} )\n");
		_display.DisplayText("=======================================================================================================================\n");
	}
	private void Process()
	{
		while (true)
		{
			IEnumerable<(Party party, ICharacter character)> partyCharacters = new Party[] { Heroes, Monsters }
				.SelectMany(party => party.Characters.Select(character => (party, character)));
			foreach ((Party party, ICharacter character) in partyCharacters)
			{
				_display.DisplayText($"It is {character.Name}'s turn...\n");
				Thread.Sleep(500);
				Party enemy = (Party)GetEnemyPartyFor(character);
				PrintBattleStatus(party, enemy);
				BattleModesMove(party, character, Mode);
				enemy.Characters.Where(ch => ch.HP == 0).ToList().ForEach(enemy.Remove);
				_display.DisplayText("\n");
				if (Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0)
					return;
			}
		}
	}
	public int Run()
	{
		Process();
		return HasWinner();
	}
}
