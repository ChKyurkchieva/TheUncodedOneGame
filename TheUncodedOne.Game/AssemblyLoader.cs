using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheUncodedOne.Game;

internal class AssemblyLoader
{
	internal List<object> Load()
	{
		List<object> objects = new List<object>();
		Assembly assembly = Assembly.LoadFrom("TheUncodedOne.Inventory.dll");

		Type[] type = assembly.GetTypes();
		foreach (Type t in type)
			objects.Add(Activator.CreateInstance(t));
		return objects;
	}
}
