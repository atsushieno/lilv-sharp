using LilvSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Driver
{
	public static void Main (string [] args)
	{
		var world = new World ();
		world.LoadAll ();

		if (args.Length == 0 || args.Contains ("--show-classes")) {

			foreach (PluginClass p in world.PluginClasses) {
				Console.WriteLine ($"<<< PluginClass {p.Uri.AsUri} >>>");
				foreach (var ppi in p.GetType ().GetProperties ()
					.Where (_ => _.PropertyType == typeof (Node))) {
					var node = (Node) ppi.GetValue (p);
					Console.WriteLine ($"  {ppi.Name}: ({node.LiteralType}) {node.Value}");
				}
			}

			Console.WriteLine ("--------------------------------------");
		}

		if (args.Length == 0 || args.Contains ("--show-plugins")) {
			foreach (Plugin plugin in world.AllPlugins) {
				Console.WriteLine ($"[ Plugin {plugin.Name.Value} ]");
				foreach (var ppi in plugin.GetType ().GetProperties ()) {
					if (ppi.PropertyType != typeof (Node) && ppi.PropertyType != typeof (Nodes))
						Console.WriteLine ($"  {ppi}: {ppi.GetValue (plugin)}");
				}

				foreach (var ppi in plugin.GetType ().GetProperties ()
					.Where (_ => _.PropertyType == typeof (Nodes))) {
					var nodes = (Nodes) ppi.GetValue (plugin);
					Console.WriteLine ($"    [NL] {ppi.Name}:");
					foreach (var node in nodes)
						Console.WriteLine ($"      ({node?.LiteralType}) {node?.Value}");
				}

				foreach (var ppi in plugin.GetType ().GetProperties ()
					.Where (_ => _.PropertyType == typeof (Node))) {
					var node = (Node) ppi.GetValue (plugin);
					Console.WriteLine ($"  [N] {ppi.Name}: ({node?.LiteralType}) {node?.Value}");
				}

				for (uint i = 0; i < plugin.NumPorts; i++) {
					Console.WriteLine ($"    ---- Port {i} ----");
					var port = plugin.GetPortByIndex (i);
					foreach (var ppi in port.GetType ().GetProperties ()) {
						if (ppi.PropertyType != typeof (Node) && ppi.PropertyType != typeof (Nodes))
							Console.WriteLine ($"    {ppi}: {ppi.GetValue (port)}");
					}

					foreach (var ppi in port.GetType ().GetProperties ()
						.Where (_ => _.PropertyType == typeof (Nodes))) {
						var nodes = (Nodes) ppi.GetValue (port);
						Console.WriteLine ($"    [NL] {ppi.Name}:");
						foreach (var node in nodes)
							Console.WriteLine ($"      ({node?.LiteralType}) {node?.Value}");
					}

					foreach (var ppi in port.GetType ().GetProperties ()
						.Where (_ => _.PropertyType == typeof (Node))) {
						var node = (Node) ppi.GetValue (port);
						Console.WriteLine (
							$"    [N] {ppi.Name}: ({node?.LiteralType}) {node?.Value}");
					}

					foreach (var prop in port.Properties)
						Console.WriteLine ($"    [P] {prop?.LiteralType}: {prop?.Value}");
				}

				foreach (var ui in plugin.UIs)
					Console.WriteLine ($"    ---- UI {ui.Uri.AsUri}");
			}

			var plugin1 = world.AllPlugins.Last ();
			var instance = plugin1.Instantiate (44100, new LV2Sharp.Feature (IntPtr.Zero));
			foreach (var ppi in instance.GetType ().GetProperties ()) {
				if (ppi.PropertyType != typeof (Node) && ppi.PropertyType != typeof (Nodes))
					Console.WriteLine ($"    {ppi}: {ppi.GetValue (instance)}");
			}

			foreach (var ppi in instance.GetType ().GetProperties ()
				.Where (_ => _.PropertyType == typeof (Nodes))) {
				var nodes = (Nodes) ppi.GetValue (instance);
				Console.WriteLine ($"    [NL] {ppi.Name}:");
				foreach (var node in nodes)
					Console.WriteLine ($"      ({node?.LiteralType}) {node?.Value}");
			}

			foreach (var ppi in instance.GetType ().GetProperties ()
				.Where (_ => _.PropertyType == typeof (Node))) {
				var node = (Node) ppi.GetValue (instance);
				Console.WriteLine ($"    [N] {ppi.Name}: ({node?.LiteralType}) {node?.Value}");
			}
		}
	}
}

