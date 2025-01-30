using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Game.Inputs;
using TheUncodedOne.Game.Players;

namespace TheUncodedOne.Game;

public class Game
{
	private List<Party> Monsters { get; set; }
	private Party Heroes { get; set; }
	private readonly IDisplay _display;
	private readonly IInput _input;
	private readonly List<string> _actionTypes;
	private readonly List<IAction> _actions;
	private readonly IActionFactory _actionFactory;
	private readonly IAttackFactory _attackFactory;
	private IInventory heroesInventory;
	private IInventory monstersInventory;
	private Mode Mode;

	public Game(List<string> actionTypes, List<IAction> actions, IDisplay display, IInput input, IActionFactory actionFactory, IAttackFactory attackFactory)
	{
		_display = display;
		_input = input;
		_actionTypes = actionTypes;
		Monsters = new List<Party>();
		_actions = actions;
		_actionFactory = actionFactory;
		_attackFactory = attackFactory;
	}
	private void InitializePlayerName(Party heroes)
	{
		string playerName;
		do
		{
			_display.DisplayText("Choose your name: ", ConsoleColor.DarkCyan);
			playerName = _input.ReadLine()!;
		} while (playerName == null);
		playerName = playerName.ToUpper();
		heroes.Characters.Add(new TrueProgrammer(playerName));
	}

	private void GameMode()
	{
		int gameMode;
		do
		{
			_display.DisplayText("Choose game mode:\n1 -> Human vs Human\n2 -> Human vs Computer\n3 -> Computer vs Computer\n", ConsoleColor.DarkGreen);
		} while (!Int32.TryParse(_input.ReadLine()!, out gameMode));
		Mode = (Mode)gameMode;
	}
	private bool MonstersWin(int result) => result == 0;
	private void SetGameBattles()
	{
		if (Mode == Mode.HumanVsHuman) 
		{
			Heroes = new Party(new HumanoidPlayer(_display, _actions), _display, heroesInventory);
			Monsters.Add(new Party(new HumanoidPlayer(_display, _actions), _display, monstersInventory));
			InitializePlayerName(Heroes);
			InitializePlayerName(Monsters[0]);
			return;	
		}
		if (Mode == Mode.HumanVsComputer)
			Heroes = new Party(new HumanoidPlayer(_display, _actions), _display, heroesInventory);

		else
			Heroes = new Party(new ComputerPlayer(_display, _actions), _display, heroesInventory);

		Monsters.Add(new Party(new ComputerPlayer(_display, _actions), _display, monstersInventory));
		Monsters[0].Characters.Add(new Skeleton());
		Monsters.Add(new Party(new ComputerPlayer(_display, _actions), _display, monstersInventory));
		Monsters[1].Characters.Add(new Skeleton());
		Monsters[1].Characters.Add(new Skeleton ());
		Monsters.Add(new Party(new ComputerPlayer(_display, _actions), _display, monstersInventory));
		Monsters[2].Characters.Add(new TheUncodedOneCharacter());
		InitializePlayerName(Heroes);
	}

	public void Run()
	{
		GameMode();
		SetGameBattles();
		for (int i = 0; i < Monsters.Count; i++)
		{
			_display.DisplayText("New battle begins!\n", ConsoleColor.Blue);
			Battle battle = new Battle(Heroes, Monsters[i], _display, _input, Mode, _actionTypes, _actionFactory, _attackFactory);
			int result = battle.Run();
			if (MonstersWin(result))
			{
				_display.DisplayText("Monsters and the Uncoded one win.", ConsoleColor.Red);
				break;
			}
		}
	}
}

public enum Mode { HumanVsHuman = 1, HumanVsComputer, ComputerVsComputer }