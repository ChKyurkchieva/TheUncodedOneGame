using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Players;

namespace TheUncodedOneGame;

public class Game
{
	private List<Party> Monsters { get; set; }
	private Party Heroes { get; set; }
	private int GameMode { get; set; }
	private void InitializePlayerName(Party heroes)
	{
		string playerName;
		do
		{
			ConsoleDisplay.DisplayText("Choose your name: ", ConsoleColor.DarkCyan);
			playerName = Console.ReadLine()!;
			ConsoleDisplay.DisplayClear();
		} while (playerName == null);
		heroes.Characters.Add(new TrueProgrammer(playerName.ToUpper()));
	}

	private void Mode()
	{
		int gameMode;
		do
		{
			ConsoleDisplay.DisplayText("Choose game mode:\n1 -> Human vs Human\n2 -> Human vs Computer\n3 -> Computer vs Computer\n");
		} while (!Int32.TryParse(Console.ReadLine()!, out gameMode));
		GameMode = gameMode;
	}
	private bool MonstersWin(int result) => result == 0;
	private void SetGameBattles()
	{
		if (GameMode == 1) // Human vs Human
		{
			Heroes = new Party(new HumanoidPlayer { });
			Monsters = new List<Party>();
			Monsters.Add(new Party(new HumanoidPlayer { }));
			//add menu for chosing characters
			Monsters[0].Characters.Add(new Skeleton { });
			InitializePlayerName(Heroes);
			return;	
		}
		if (GameMode == 2)  // Human vs Computer
			Heroes = new Party(new HumanoidPlayer { });

		else // Computer vs Computer
			Heroes = new Party(new ComputerPlayer { });

		Monsters = new List<Party>();
		Monsters.Add(new Party(new ComputerPlayer { }));
		Monsters[0].Characters.Add(new Skeleton { });
		Monsters.Add(new Party(new ComputerPlayer { }));
		Monsters[1].Characters.Add(new Skeleton { });
		Monsters[1].Characters.Add(new Skeleton { });
		Monsters.Add(new Party(new ComputerPlayer { }));
		Monsters[2].Characters.Add(new TheUncodedOne { });
		InitializePlayerName(Heroes);
	}
	public Game()
	{
		Mode();
		SetGameBattles();
	}
	public void Run()
	{
		for (int i = 0; i < Monsters.Count; i++)
		{
			ConsoleDisplay.DisplayText("New battle begins!\n", ConsoleColor.Blue);
			Battle battle = new Battle(Heroes, Monsters[i]);
			int result = battle.Run();
			if (MonstersWin(result))
			{
				ConsoleDisplay.DisplayText("Monsters and the Uncoded one win.", ConsoleColor.Red);
				break;
			}
		}
	}
}
