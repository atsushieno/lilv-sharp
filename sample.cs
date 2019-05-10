using LilvSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Driver
{
	public static void Main ()
	{
		var world = new World ();
		world.LoadAll ();
		foreach (PluginClass p in world.GetPluginClasses ()) {
			Console.WriteLine ($"---- PluginClass {p.Uri.Value} ----");
			foreach (var ppi in p.GetType ().GetProperties ().Where (_ => _.PropertyType == typeof (Node))) {
				var node = (Node) ppi.GetValue (p);
				Console.WriteLine ($"  {ppi.Name}: ({node.LiteralType}) {node.Value}");
			}
		}
		
		Console.WriteLine ("--------------------------------------");

		foreach (Plugin p in world.GetAllPlugins ()) {
			Console.WriteLine ($"[ Plugin {p.Name.Value} ]");
			foreach (var ppi in p.GetType ().GetProperties ().Where (_ => _.PropertyType == typeof (Node))) {
				var node = (Node) ppi.GetValue (p);
				Console.WriteLine ($"  {ppi.Name}: ({node.LiteralType}) {node.Value}");
			}
		}
	}
}

