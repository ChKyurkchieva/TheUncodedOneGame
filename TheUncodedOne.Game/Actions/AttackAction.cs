using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Attacks;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;

namespace TheUncodedOne.Game.Actions;

public class AttackAction : IAction
{
    private readonly IAttack _attack;
    private IDisplay _display;
    public AttackAction(IAttack attack, IDisplay display)
    {
        _attack = attack;
        _display = display;
    }
    public void Run(IBattle battle, ICharacter character)
    {
        ICharacter target = battle.GetEnemyPartyFor(character).Characters[new Random().Next(battle.GetEnemyPartyFor(character).Characters.Count)];
        _display.DisplayText($"{character.Name} " + $"{_attack.Name} " + $"{target.Name}\n");
        AttackData data = _attack.Create();
        target.HP -= data.Damage;
        _display.DisplayText($"{target.Name} is now at {target.HP}/{target.MaxHP} HP.\n");
    }
}
