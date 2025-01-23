namespace TheUncodedOne.Contract.Interfaces;

public interface IPlayer
{
    IAction ChooseAction(IBattle battle, ICharacter character, string typeAction);
}
