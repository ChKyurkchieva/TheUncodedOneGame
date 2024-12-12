using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOneGame.Attacks;

namespace TheUncodedOneGame.Characters;
public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack DefaultAttack { get; }
    private int _hp;
    public int HP { get => _hp; set => _hp = Math.Clamp(value, 0, MaxHP); }
    public int MaxHP { get; }
    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}