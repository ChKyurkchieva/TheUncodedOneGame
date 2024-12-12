using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Attacks;

namespace TheUncodedOneGame.Characters;

public class Skeleton : Character
{
    public override string Name => "SKELETON";
	public override IAttack DefaultAttack { get; } = new BoneCrunchAttack();
	public Skeleton() : base(5) { }
   
}
