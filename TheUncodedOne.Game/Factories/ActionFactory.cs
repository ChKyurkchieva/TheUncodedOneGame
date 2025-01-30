using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Net.Http.Headers;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;

namespace TheUncodedOne.Game.Factories;
public class ActionFactory : IActionFactory
{
	private IServiceProvider _provider = null!;
	private List<string> _actionTypes;

	public ActionFactory(IServiceProvider provider, List<string> actionTypes)
	{
		_provider = provider;
		_actionTypes = actionTypes;
	} 
	public IAction CreateAction(string actionType)
	{
		var actions = _provider.GetServices<IAction>();

		var action = actions.FirstOrDefault(a => a.Name.Contains(actionType, StringComparison.OrdinalIgnoreCase));
		if (action == null) 
			throw new InvalidOperationException($"No IAction implementation found for actionType: {actionType}");

		return action;
	}
}
