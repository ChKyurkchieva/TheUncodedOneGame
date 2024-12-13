using TheUncodedOneGame;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Players;



Party heroes = new Party(new ComputerPlayer { });
List<Party> monsterParties = new List<Party>();
monsterParties.Add(new Party(new ComputerPlayer { }));
monsterParties[0].Characters.Add(new Skeleton { });
monsterParties.Add(new Party(new ComputerPlayer { }));
monsterParties[1].Characters.Add(new Skeleton { });
monsterParties[1].Characters.Add(new Skeleton { });
monsterParties.Add(new Party(new ComputerPlayer{ }));
monsterParties[2].Characters.Add(new TheUncodedOne { });

string playerName;
do
{
	ConsoleDisplay.DisplayText("Choose your name: ", ConsoleColor.DarkCyan);
	playerName = Console.ReadLine()!;
	Console.Clear();
} while (playerName == null);

heroes.Characters.Add(new TrueProgrammer(playerName.ToUpper()));
for (int i = 0; i < monsterParties.Count; i++)
{
	ConsoleDisplay.DisplayText("New battle begins!\n", ConsoleColor.Blue);
	Battle battle = new Battle(heroes, monsterParties[i]);
	int result = battle.Run();
	if (MonstersWin(result))
	{
		ConsoleDisplay.DisplayText("Monsters and the Uncoded one win.", ConsoleColor.Red);
		break;
	}
}
bool MonstersWin(int result) => result == 0;