namespace TheUncodedOne.Contract.Interfaces;

public interface IActionFactory
{
	IAction CreateAction(string actionType);
}
