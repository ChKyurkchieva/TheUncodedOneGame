using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using TheUncodedOne.Contract.Interfaces;
using TheUncodedOne.Game.Actions;

namespace TheUncodedOne.Game.Factories;
public class ActionFactory
{
	public ActionFactory() { }
	public IAction CreateAction(ServiceProvider provider, string actionType)
	{
		var actions = provider.GetServices<IAction>();

		var action = actions.FirstOrDefault(a => a.GetType().Name.Contains(actionType, StringComparison.OrdinalIgnoreCase));

		if (action == null)
		{
			throw new InvalidOperationException($"No IAction implementation found for actionType: {actionType}");
		}

		return action;
	}
	public void DisplayActions(ServiceProvider provider)
	{
		var display = provider.GetService<IDisplay>();
		var actions = provider.GetServices<IAction>().ToList();
		actions.ForEach(x => display.DisplayText(x.ToString()));
	}
}
