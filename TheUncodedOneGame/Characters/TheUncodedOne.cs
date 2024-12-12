using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Attacks;

namespace TheUncodedOneGame.Characters;

public class TheUncodedOne : Character
{
	public override string Name => "THE UNCODED ONE";
	public override IAttack DefaultAttack { get; } = new UnravelingAttack();
	public TheUncodedOne() : base(15) { }
}
