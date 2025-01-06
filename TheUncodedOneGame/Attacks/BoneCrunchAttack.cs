using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;

namespace TheUncodedOneGame.Attacks;

public class BoneCrunchAttack : IAttack
{
    public string Name => "BONE CRUNCH";
    public AttackData Create() => new AttackData(new Random().Next(2));
}
