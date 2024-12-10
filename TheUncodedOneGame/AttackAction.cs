using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public class AttackAction : IAction
{
	private readonly IAttack _attack;
	public AttackAction(IAttack attack) => _attack = attack;
	public void Run(Battle battle, Character character) => Console.WriteLine($"{character.Name} " +
		$"{_attack.Name} " + 
		$"{battle.GetEnemyPartyFor(character).Characters[new Random().Next(battle.GetEnemyPartyFor(character).Characters.Count)].Name}");
}
