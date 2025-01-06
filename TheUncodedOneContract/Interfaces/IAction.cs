using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOneContract.Interfaces;

public interface IAction
{
    void Run(IBattle battle, ICharacter character);
}

