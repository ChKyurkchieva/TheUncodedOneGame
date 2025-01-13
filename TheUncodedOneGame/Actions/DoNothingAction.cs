﻿using TheUncodedOne.Contract.Interfaces;
using TheUncodedOneGame.Characters;

namespace TheUncodedOne.Game.Actions;

public class DoNothingAction : IAction
{
    IDisplay _display;

    public DoNothingAction(IDisplay display)  => _display = display;
    public void Run(IBattle battle, ICharacter character) => _display.DisplayText($"{character.Name} did NOTHING...");
}
