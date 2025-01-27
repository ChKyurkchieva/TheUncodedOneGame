using Microsoft.Extensions.DependencyInjection;
using System;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Attacks;

namespace TheUncodedOne.Game.Factories;
public class AttackFactory : IAttackFactory
{
	private readonly IServiceProvider _serviceProvider;

	public AttackFactory(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}
	public IAttack? CreateAttack(AttackType attackType)
	{
		var attacks = _serviceProvider.GetServices<IAttack>();
		var attack = attacks.FirstOrDefault(a => a.GetType().Name.Contains(attackType.ToString(), StringComparison.OrdinalIgnoreCase));
		if(attack == null)
			throw new InvalidOperationException($"No IAction implementation found for actionType: {attackType.ToString()}");
		return attack;
	}
}

