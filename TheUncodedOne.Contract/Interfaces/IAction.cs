namespace TheUncodedOne.Contract.Interfaces;

public interface IAction
{
    public string Name { get; }
    void Run(IBattle battle, ICharacter character);
}

