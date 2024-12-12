using TheUncodedOneGame;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Players;

Party heroes = new Party(new ComputerPlayer());
List<Party> monsterParties = new List<Party>();
monsterParties.Add(new Party(new ComputerPlayer()));
monsterParties[0].Characters.Add(new Skeleton { });
monsterParties.Add(new Party(new ComputerPlayer()));
monsterParties[1].Characters.Add(new Skeleton { });
monsterParties[1].Characters.Add(new Skeleton { });
monsterParties.Add(new Party(new ComputerPlayer()));
monsterParties[2].Characters.Add(new TheUncodedOne { });
string playerName;
do
{
	Console.Write("Choose your name: ");
	playerName = Console.ReadLine()!;
	Console.Clear();
} while (playerName == null);

heroes.Characters.Add(new TrueProgrammer(playerName.ToUpper()));
for (int i = 0; i < monsterParties.Count; i++)
{
	Console.WriteLine("New battle begins!\n");
	Battle battle = new Battle(heroes, monsterParties[i]);
	int result = battle.Run();
	if (MonstersWin(result))
	{
		Console.WriteLine("Monsters and the Uncoded one win.");
		break;
	}
}
bool MonstersWin(int result) => result == 0;