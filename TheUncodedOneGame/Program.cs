using TheUncodedOneGame;

Party heroes = new Party(new ComputerPlayer());
Party monsters = new Party(new ComputerPlayer());
string playerName;
do
{
	Console.Write("Choose your name: ");
	playerName = Console.ReadLine();
	Console.Clear();
} while (playerName == null);

heroes.Characters.Add(new TrueProgrammer(playerName.ToUpper()));
monsters.Characters.Add(new Skeleton { });
Battle battle = new Battle(heroes, monsters);
battle.Run();
