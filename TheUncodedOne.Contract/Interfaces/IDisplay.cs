﻿namespace TheUncodedOne.Contract.Interfaces;

public interface IDisplay
{
	void DisplayClear();
	void DisplayText(string text, ConsoleColor color = ConsoleColor.White);
}

public enum ConsoleColor
{
	Black = 0,
	DarkBlue = 1,
	DarkGreen = 2,
	DarkCyan = 3,
	DarkRed = 4,
	DarkMagenta = 5,
	DarkYellow = 6,
	Gray = 7,
	DarkGray = 8,
	Blue = 9,
	Green = 10,
	Cyan = 11,
	Red = 12,
	Magenta = 13,
	Yellow = 14,
	White = 15
}