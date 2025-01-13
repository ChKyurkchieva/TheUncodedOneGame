namespace TheUncodedOne.Contract.Interfaces;

public interface IAction
{
    void Run(IBattle battle, ICharacter character);
}

