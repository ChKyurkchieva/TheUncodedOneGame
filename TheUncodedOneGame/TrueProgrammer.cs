using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public class TrueProgrammer : Character
{
	public override string Name {  get; }
	public override IAttack DefaultAttack { get; } = new PunchAttack();
	public TrueProgrammer(string name) : base(25)
	{
		Name = name;
		HP = 25;
	}
}
