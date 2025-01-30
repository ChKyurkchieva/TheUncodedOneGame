using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheUncodedOne.Contract.Interfaces;

namespace TheUncodedOne.Game;

internal class AssemblyLoader
{
	internal List<IBootstrapper> Load()
	{
		List<IBootstrapper> bootstrapers = new List<IBootstrapper>();
		Assembly assembly = Assembly.LoadFrom("TheUncodedOne.Inventory.dll");

		Type[] type = assembly.GetTypes();
		foreach (Type t in type)
		{
			if(t.IsAssignableTo(typeof(IBootstrapper)))
				bootstrapers.Add((IBootstrapper?)Activator.CreateInstance(t) ?? throw new InvalidOperationException($"Failed to construct {t.Name}"));
		}
			return bootstrapers;
	}
}
