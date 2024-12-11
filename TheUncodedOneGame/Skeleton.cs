﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame;

public class Skeleton : Character
{ 
	public override string Name => "SKELETON";
	public Skeleton() : base(5) { }
	public override IAttack DefaultAttack { get; } = new BoneCrunchAttack();
}
