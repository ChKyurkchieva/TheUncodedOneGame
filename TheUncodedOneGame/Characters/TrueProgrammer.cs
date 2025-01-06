using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneContract.Interfaces;
using TheUncodedOneGame.Attacks;

namespace TheUncodedOneGame.Characters;

public class TrueProgrammer : ICharacter
{
    private int _hp;
    public string Name { get; }
    public IAttack DefaultAttack { get; } = new PunchAttack();
    public int MaxHP { get; }
    public int HP { get => _hp; set => _hp = Math.Clamp(_hp, 0, MaxHP); }
    public TrueProgrammer(string name)
    {
        Name = name;
        HP = MaxHP = 25;
    }
}
