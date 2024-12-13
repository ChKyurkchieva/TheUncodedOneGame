using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Attacks;
using TheUncodedOneGame.Characters;
using TheUncodedOneGame.Displays;

namespace TheUncodedOneGame.Actions;

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private IDisplay _display;
    public AttackAction(IAttack attack, IDisplay display)
    {
        _attack = attack;
        _display = display;
    }
    public void Run(Battle battle, Character character)
    {
        Character target = battle.GetEnemyPartyFor(character).Characters[new Random().Next(battle.GetEnemyPartyFor(character).Characters.Count)];
        _display.DisplayText($"{character.Name} " + $"{_attack.Name} " + $"{target.Name}\n");
        AttackData data = _attack.Create();
        target.HP -= data.Damage;
        _display.DisplayText($"{target.Name} is now at {target.HP}/{target.MaxHP} HP.\n");
    }
}
