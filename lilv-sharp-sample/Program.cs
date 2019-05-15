using LilvSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

public class Driver
{
	static readonly IDictionary<string, string> known_namespaces = new Dictionary<string, string> () {
		{ "http://www.w3.org/2000/01/rdf-schema", "LV2Sharp.RdfSchema" },
		{ "http://www.w3.org/1999/02/22-rdf-syntax-ns", "LV2Sharp.RdfSyntax" },
		{ "http://www.w3.org/2002/07/owl", "LV2Sharp.Owl" },
		{ "http://xmlns.com/foaf/0.1/", "LV2Sharp.Foaf" },
		{ "http://purl.org/dc/terms/", "LV2Sharp.Dct" },
		{ "http://usefulinc.com/ns/doap", "LV2Sharp.Doap" },
		{ "http://ontologi.es/doap-bugs", "LV2Sharp.DoapBugs" },
		{ "http://lv2plug.in/ns/lv2core", "LV2Sharp.LV2" },
		{ "http://lv2plug.in/ns/ext/atom", "LV2Sharp.LV2.AtomNS" },
		{ "http://lv2plug.in/ns/ext/dynmanifest", "LV2Sharp.LV2.DynManifest" },
		{ "http://lv2plug.in/ns/ext/event", "LV2Sharp.LV2.EventNS" },
		{ "http://lv2plug.in/ns/ext/log", "LV2Sharp.LV2.Log" },
		{ "http://lv2plug.in/ns/ext/midi", "LV2Sharp.LV2.Midi" },
		{ "http://lv2plug.in/ns/ext/morph", "LV2Sharp.LV2.Morph" },
		{ "http://lv2plug.in/ns/ext/options", "LV2Sharp.LV2.Options" },
		{ "http://lv2plug.in/ns/ext/parameters", "LV2Sharp.LV2.Parameters" },
		{ "http://lv2plug.in/ns/ext/patch", "LV2Sharp.LV2.PatchNS" },
		{ "http://lv2plug.in/ns/ext/presets", "LV2Sharp.LV2.Presets" },
		{ "http://lv2plug.in/ns/ext/port-groups", "LV2Sharp.LV2.PortGroups" },
		{ "http://lv2plug.in/ns/ext/state", "LV2Sharp.LV2.StateNS" },
		{ "http://lv2plug.in/ns/ext/time", "LV2Sharp.LV2.TimeNS" },
		{ "http://lv2plug.in/ns/extensions/ui", "LV2Sharp.LV2.UINS" },
		{ "http://lv2plug.in/ns/extensions/units", "LV2Sharp.LV2.Units" },
	};

	public static void Main (string [] args)
	{
		if (args.Length == 0 || args.Contains ("--help")) {
			Console.WriteLine (@"
'list' command: shows list of things in the 'world'
	--show-classes	show list of types in the world.
	--show-plugins	show list of plugins in the world.

'generate' command: generates strongly-typed C# code for types
			");
			return;
		}

		if (args.Contains ("list"))
			ShowList (args);
		else if (args.Contains ("generate"))
			Generate (args);
	}

	static void Generate (string [] args)
	{
		var world = new World ();
		world.LoadAll ();
		var q = '"';
		
		Console.WriteLine (@"
using System;
using LV2Sharp;

namespace LV2Sharp
{
	public class LabelAttribute : Attribute
	{
		public LabelAttribute (string label) { Label = label; }
		public string Label { get; set; }
	}
	public class PluginUriAttribute : Attribute
	{
		public PluginUriAttribute (string name) { Name = name; }
		public string Name { get; set; }
	}
}
");

		var dic = new Dictionary<string, List<PluginClass>> ();
		foreach (var type in world.PluginClasses) {
			string ns = known_namespaces
					    .FirstOrDefault (e =>
						    type.Uri.AsString.StartsWith (e.Key, StringComparison.Ordinal))
					    .Value ?? "LV2Sharp";
			
			List<PluginClass> list;
			if (!dic.TryGetValue (ns, out list)) {
				list = new List<PluginClass> ();
				dic [ns] = list;
			}
			list.Add (type);
		}

		string getNS (string uri) =>
			known_namespaces.FirstOrDefault (e => uri.StartsWith (e.Key)).Value ?? "LV2Sharp";

		foreach (var e in dic) {

			Console.WriteLine ($"namespace {e.Key}");
			Console.WriteLine ("{");

			foreach (var type in e.Value) {
				string name = type.Uri.AsString.Split ('/', '#').Last ();
				string parentName = "System.Object";
				if (type.ParentUri != null) {
					string parentNS = getNS (type.ParentUri.AsString);
					parentName =
						type.Uri.AsString == "http://www.w3.org/2000/01/rdf-schema#Class"
						|| type.Uri.AsString == type.ParentUri.AsString
						|| !type.ParentUri.IsUri
						? "System.Object"
						: parentNS +'.' + type.ParentUri.AsString.Split ('/', '#').Last ();
					// this is a special case. It is specified as inherited from owl:Thing but owl:Thing is NOT a rdfs:Class.
					// Not sure if it is a specification bug in OWL.
					if (parentName == "LV2Sharp.Owl.Thing")
						parentName = "System.Object";
				}
				Console.WriteLine ($@"
	[Label ({q}{type.Label.Value}{q})]
	[PluginUri ({q}{type.Uri.Value}{q})]
	public class {name} : {parentName}
	{{
	}}
");
			}
			
			Console.WriteLine ("}");
		}
	}
	
	static void ShowList (string [] args)
	{
		var world = new World ();
		world.LoadAll ();

		if (args.Length == 1 || args.Contains ("--show-classes")) {

			foreach (PluginClass p in world.PluginClasses) {
				Console.WriteLine ($"<<< PluginClass {p.Uri.AsUri} >>>");
				foreach (var ppi in p.GetType ().GetProperties ()
					.Where (_ => _.PropertyType == typeof (Node))) {
					var node = (Node) ppi.GetValue (p);
					Console.WriteLine ($"  {ppi.Name}: ({node?.LiteralType}) {node?.Value}");
				}
			}

			Console.WriteLine ("--------------------------------------");
		}

		if (args.Length == 1 || args.Contains ("--show-plugins")) {
			foreach (Plugin plugin in world.AllPlugins) {
				Console.WriteLine ($"[ Plugin {plugin.Name.Value} : {plugin.Class.Uri.Value} ]");
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
					var port = plugin.GetPortByIndex (i);
					Console.WriteLine ($"    ---- Port {i} ----");
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

			Console.WriteLine ("--------------------------------------");
			var plugin1 = world.AllPlugins.Last (p => p.RequiredFeatures == null || p.RequiredFeatures.Count == 0);
			var instance = plugin1.Instantiate (44100,
				new LV2Sharp.Feature (IntPtr.Zero));
			Console.WriteLine ("---- PLUGIN: " + plugin1.Name.Value);
			
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
			
			instance.ConnectPort (0, IntPtr.Zero);
			instance.Activate ();
			instance.Deactivate ();
		}
	}
}

