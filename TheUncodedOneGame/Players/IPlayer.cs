using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Actions;
using TheUncodedOneGame.Characters;

namespace TheUncodedOneGame.Players;

public interface IPlayer
{
    IAction ChooseAction(Battle battle, Character character, int typeAction);
}
