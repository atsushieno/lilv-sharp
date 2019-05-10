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

		foreach (Plugin plugin in world.GetAllPlugins ()) {
			Console.WriteLine ($"[ Plugin {plugin.Name.Value} ]");
			foreach (var ppi in plugin.GetType ().GetProperties ().Where (_ => _.PropertyType != typeof (Node))) {
				Console.WriteLine ($"  {ppi}: {ppi.GetValue (plugin)}");
			}
			foreach (var ppi in plugin.GetType ().GetProperties ().Where (_ => _.PropertyType == typeof (Node))) {
				var node = (Node) ppi.GetValue (plugin);
				Console.WriteLine ($"  [N] {ppi.Name}: ({node.LiteralType}) {node.Value}");
			}
			for (int i = 0; i < plugin.NumPorts; i++) {
				Console.WriteLine ($"    ---- Port {i} ----");
				var port = plugin.GetPortByIndex (i);
				foreach (var ppi in port.GetType ().GetProperties ().Where (_ => _.PropertyType != typeof (Node))) {
					Console.WriteLine ($"    {ppi}: {ppi.GetValue (port)}");
				}
				foreach (var ppi in port.GetType ().GetProperties ().Where (_ => _.PropertyType == typeof (Node))) {
					var node = (Node) ppi.GetValue (port);
					Console.WriteLine ($"    [N] {ppi.Name}: ({node.LiteralType}) {node.Value}");
				}
			}
		}
	}
}

