using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneGame.Attacks;
public record AttackData(int Damage);
public interface IAttack
{
    string Name { get; }
    AttackData Create();
}
