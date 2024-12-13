using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Attacks;
using TheUncodedOneGame.Characters;

namespace TheUncodedOneGame.Actions;

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    public AttackAction(IAttack attack) => _attack = attack;
    public void Run(Battle battle, Character character)
    {
        Character target = battle.GetEnemyPartyFor(character).Characters[new Random().Next(battle.GetEnemyPartyFor(character).Characters.Count)];
        ConsoleDisplay.DisplayText($"{character.Name} " + $"{_attack.Name} " + $"{target.Name}\n", ConsoleColor.Magenta);
        AttackData data = _attack.Create();
        target.HP -= data.Damage;
        ConsoleDisplay.DisplayText($"{target.Name} is now at {target.HP}/{target.MaxHP} HP.\n");
    }
}
