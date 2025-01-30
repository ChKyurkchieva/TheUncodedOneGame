using System.Runtime.CompilerServices;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Attacks;
using TheUncodedOne.Game.Characters;
using TheUncodedOne.Game.Displays;
using TheUncodedOne.Game.Factories;
using TheUncodedOne.Game.Players;
using TheUncodedOne.Game;
namespace TheUncodedOne.Game.Actions;

public class AttackAction : IAction
{
    private readonly IAttackFactory _attackFactory;
    private readonly IDisplay _display;
    private readonly IInput _input;
    public AttackAction(IAttackFactory attackFactory, IDisplay display, IInput input)
    {
        _attackFactory = attackFactory;
        _display = display;
        _input = input;
    }
	public string Name { get; } = "AttackAction";

	public void Run(IBattle battle, ICharacter character)
    {
        ICharacter target = battle.GetEnemyPartyFor(character).Characters[new Random().Next(battle.GetEnemyPartyFor(character).Characters.Count)];
        AttackType attackType = DefaultAttack(character);
        if((battle.GetMode() == BattleMode.HumanVsHuman || battle.GetMode() == BattleMode.HumanVsComputer ) && character is TrueProgrammer)
            attackType = ChooseAttack(character);
        IAttack attack = _attackFactory.CreateAttack(attackType);
        _display.DisplayText($"{character.Name} " + $"{attack.Name.ToUpperInvariant()} " + $"{target.Name}\n");
        AttackData data = attack.Create();
        target.HP -= data.Damage;
        _display.DisplayText($"{target.Name} is now at {target.HP}/{target.MaxHP} HP.\n");
    }
    
    private AttackType ChooseAttack(ICharacter character)
    {
		AttackType attackType = AttackType.BoneCrunch;
        string result;
        var attacks = Enum.GetValues(typeof(AttackType));
		do
		{
			_display.DisplayText("Choose attack:\n", ConsoleColor.Yellow);
            foreach (var attack in attacks)
                _display.DisplayText($"\t{attack}\n");
			_display.DisplayText("Which attack do you choose? ", ConsoleColor.Yellow);
			result = _input.ReadLine();
            if (result is null || result == string.Empty)
            {
                return attackType = DefaultAttack(character);
            }
            switch (result.ToLowerInvariant()) 
            {
                case "bonecrunch": attackType = AttackType.BoneCrunch;
					break;
                case "punch": attackType = AttackType.Punch;
                    break;
                case "unraveling": attackType = AttackType.Unraveling;
                    break;
            }
		} while (result.ToLowerInvariant() != AttackType.Punch.ToString().ToLowerInvariant() && 
        result.ToLowerInvariant() != AttackType.BoneCrunch.ToString().ToLowerInvariant()
        && result.ToLowerInvariant() != AttackType.Unraveling.ToString().ToLowerInvariant());

		return attackType;
	}
    private AttackType DefaultAttack(ICharacter character)
    {
        AttackType attack;
        if (character is Skeleton)
            attack = AttackType.BoneCrunch;
        else if (character is TrueProgrammer)
            attack = AttackType.Punch;
        else
            attack = AttackType.Unraveling;
        return attack;
    }
}
