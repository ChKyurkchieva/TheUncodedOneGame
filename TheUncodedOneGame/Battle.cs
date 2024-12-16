using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;

namespace TheUncodedOneGame;

public class Battle
{
	private Party Heroes;
	private Party Monsters;
	private IDisplay _display;
	private Mode _mode;

	public Mode Mode { get => _mode; set => _mode = value; }

	internal Party GetEnemyPartyFor(Character character)
	{
		return Heroes.Characters.Contains(character) ? Monsters : Heroes;
	}

	public Battle(Party heroes, Party monsters, IDisplay display, Mode mode)
	{
		Heroes = heroes;
		Monsters = monsters;
		_display = display;
		_mode = mode;
	}

	int HasWinner()
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
	public int Run()
	{
		Process();
		return HasWinner();
	}
	private int GetTypeAction()
	{
		int result;
		do
		{
			_display.DisplayText("0 -> Standard attack\n1 -> Do Nothing\n");
			_display.DisplayText("What do you want to do? ");
		} while (!Int32.TryParse(Console.ReadLine(), out result) && !(result == 0 || result == 1));
		return result;
	}
	private void BattleModesMove(Party party, Character character, Mode mode)
	{
		if (mode == Mode.HumanVsHuman || (mode == Mode.HumanVsComputer && party == Heroes))
		{
			int typeAction = GetTypeAction();
			party.Player.ChooseAction(this, character, typeAction).Run(this, character);
			return;
		}
		party.Player.ChooseAction(this, character, 0).Run(this, character);
	}

	private void Process()
	{
		while (true)
		{
			IEnumerable<(Party party, Character character)> partyCharacters = new Party[] { Heroes, Monsters }
				.SelectMany(party => party.Characters.Select(character => (party, character)));
			foreach ((Party party, Character character) in partyCharacters)
			{
				_display.DisplayText($"It is {character.Name}'s turn...\n");
				Thread.Sleep(500);
				BattleModesMove(party, character, Mode);
				Party enemy = GetEnemyPartyFor(character);
				enemy.Characters.Where(ch => ch.HP == 0).ToList().ForEach(enemy.Remove);
				_display.DisplayText("\n");
				if (Heroes.Characters.Count == 0 || Monsters.Characters.Count == 0)
					return;
			}
		}
	}
}
