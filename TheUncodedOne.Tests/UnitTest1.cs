using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Players;
using ConsoleColor = TheUncodedOne.Contract.Interfaces.ConsoleColor;
namespace TheUncodedOne.Tests;


public class MockDisplay : IDisplay
{
	private List<(string, ConsoleColor)> _mockDisplayText;
	internal IReadOnlyList<(string Text, ConsoleColor Color)> MockDisplayText => _mockDisplayText; 
	public MockDisplay()
	{
		_mockDisplayText = new List<(string, ConsoleColor)>();
	}
	public void DisplayClear() => _mockDisplayText.Clear();
	public void DisplayText(string text, ConsoleColor color) => _mockDisplayText.Add((text, color));
}
public class MockInput : IInput
{
	List<string> _input;
	IEnumerator<string> _enumerator;
	public MockInput(params string[] args)
	{
		_input = new List<string>(args);
		_enumerator = _input.GetEnumerator();
	}
	public string ReadLine()
	{
		if(_enumerator.MoveNext())
			return _enumerator.Current;
		throw new ArgumentOutOfRangeException("Expected more input");
	}
}
	public class Tests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void SinglePartiesComputerVsComputerTest()
	{
		MockDisplay _display = new MockDisplay();
		IPlayer firstPlayer = new ComputerPlayer(_display);
		IPlayer secondPlayer = new ComputerPlayer(_display);
		Party Heroes = new Party(firstPlayer, _display);
		Heroes.Characters.Add(new Skeleton());
		List<Party> Monsters = new List<Party> { };
		Monsters.Add(new Party(new ComputerPlayer(_display), _display));
		Monsters[0].Characters.Add(new Skeleton());
		Battle testBattle = new Battle(Heroes, Monsters[0], _display, null, Mode.ComputerVsComputer);

		testBattle.Run();
		
		_display.MockDisplayText.Should().ContainSingle(x => (x.Text.Contains("win") || x.Text.Contains("defeated")));
	}
	[Test]
	public void SinglePartiesHumanVsComputerTest()
	{
		MockDisplay _display = new MockDisplay();
		var repeat = Enumerable.Repeat<string>("0", 20).ToArray();
		MockInput input = new MockInput(repeat);
		IPlayer firstPlayer = new HumanoidPlayer(_display);
		IPlayer secondPlayer = new ComputerPlayer(_display);
		Party Heroes = new Party(firstPlayer, _display);
		Heroes.Characters.Add(new TrueProgrammer("Cortana"));
		List<Party> Monsters = new List<Party> { };
		Monsters.Add(new Party(new ComputerPlayer(_display), _display));
		Monsters[0].Characters.Add(new Skeleton());
		Monsters[0].Characters.Add(new Skeleton());
		Battle testBattle = new Battle(Heroes, Monsters[0], _display, input, Mode.HumanVsComputer);

		testBattle.Run();

		_display.MockDisplayText.Should().ContainSingle(x => (x.Text.Contains("win") || x.Text.Contains("defeated")));
	}
	[Test]
	public void SinglePartiesHumanVsHumanTest()
	{
		MockDisplay _display = new MockDisplay();
		var repeat = Enumerable.Repeat<string>("0", 50).ToArray();
		MockInput input = new MockInput(repeat);
		IPlayer firstPlayer = new HumanoidPlayer(_display);
		IPlayer secondPlayer = new HumanoidPlayer(_display);
		Party Heroes = new Party(firstPlayer, _display);
		Heroes.Characters.Add(new TrueProgrammer("Cortana"));
		List<Party> Monsters = new List<Party> { };
		Monsters.Add(new Party(new HumanoidPlayer(_display), _display));
		Monsters[0].Characters.Add(new TrueProgrammer("Phoenix"));
		Battle testBattle = new Battle(Heroes, Monsters[0], _display, input, Mode.HumanVsHuman);
	
		testBattle.Run();

		_display.MockDisplayText.Should().ContainSingle(x => (x.Text.Contains("win") || x.Text.Contains("defeated")));
	}
}