﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;
using TheUncodedOneGame.Players;

namespace TheUncodedOneGame;

public class Party
{
	public IPlayer Player { get; }
	public List<Character> Characters { get; } = new List<Character>();
	private IDisplay _display;
	public Party(IPlayer player, IDisplay display)
	{
		_display = display;
		Player = player;
	}

	public void Remove(Character character)
	{
		if (Characters.Remove(character))
			_display.DisplayText($"\n{character.Name} has been removed successfully!\n", ConsoleColor.Yellow);
	}
}
