using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;
using TheUncodedOneGame.Players;

namespace TheUncodedOneGame;

public class Game
{
	private List<Party> Monsters { get; set; }
	private Party Heroes { get; set; }
	private int GameMode { get; set; }
	private IDisplay _display;
	private void InitializePlayerName(Party heroes)
	{
		string playerName;
		do
		{
			_display.DisplayText("Choose your name: ", ConsoleColor.DarkCyan);
			playerName = Console.ReadLine()!;
			_display.DisplayClear();
		} while (playerName == null);
		heroes.Characters.Add(new TrueProgrammer(playerName.ToUpper()));
	}

	private void Mode()
	{
		int gameMode;
		do
		{
			_display.DisplayText("Choose game mode:\n1 -> Human vs Human\n2 -> Human vs Computer\n3 -> Computer vs Computer\n");
		} while (!Int32.TryParse(Console.ReadLine()!, out gameMode));
		GameMode = gameMode;
	}
	private bool MonstersWin(int result) => result == 0;
	private void SetGameBattles()
	{
		if (GameMode == 1) // Human vs Human
		{
			Heroes = new Party(new HumanoidPlayer(_display), _display);
			Monsters = new List<Party>();
			Monsters.Add(new Party(new HumanoidPlayer(_display), _display));
			//add menu for chosing characters
			Monsters[0].Characters.Add(new Skeleton());
			InitializePlayerName(Heroes);
			return;	
		}
		if (GameMode == 2)  // Human vs Computer
			Heroes = new Party(new HumanoidPlayer(_display), _display);

		else // Computer vs Computer
			Heroes = new Party(new ComputerPlayer(_display), _display);

		Monsters = new List<Party>();
		Monsters.Add(new Party(new ComputerPlayer(_display), _display));
		Monsters[0].Characters.Add(new Skeleton());
		Monsters.Add(new Party(new ComputerPlayer(_display), _display));
		Monsters[1].Characters.Add(new Skeleton());
		Monsters[1].Characters.Add(new Skeleton ());
		Monsters.Add(new Party(new ComputerPlayer(_display), _display));
		Monsters[2].Characters.Add(new TheUncodedOne());
		InitializePlayerName(Heroes);
	}
	public Game()
	{
		_display = new ConsoleDisplay();
		Mode();
		SetGameBattles();
	}
	public void Run()
	{
		for (int i = 0; i < Monsters.Count; i++)
		{
			_display.DisplayText("New battle begins!\n", ConsoleColor.Blue);
			Battle battle = new Battle(Heroes, Monsters[i], _display);
			int result = battle.Run();
			if (MonstersWin(result))
			{
				_display.DisplayText("Monsters and the Uncoded one win.", ConsoleColor.Red);
				break;
			}
		}
	}
}
