using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LV2Sharp;
using Lv2Sharp.NativeInterop;
using Natives = LilvSharp.NativeInterop.Natives;

namespace LilvSharp
{
	public static class LV2CoreUris
	{
		public const string LV2CoreUri = "http://lv2plug.in/ns/lv2core";
		const string LV2_CORE_PREFIX = LV2CoreUri + "#";

		public const string
			AllpassPlugin = LV2_CORE_PREFIX + "AllpassPlugin",
			AmplifierPlugin = LV2_CORE_PREFIX + "AmplifierPlugin",
			AnalyserPlugin = LV2_CORE_PREFIX + "AnalyserPlugin",
			AudioPort = LV2_CORE_PREFIX + "AudioPort",
			BandpassPlugin = LV2_CORE_PREFIX + "BandpassPlugin",
			CVPort = LV2_CORE_PREFIX + "CVPort",
			ChorusPlugin = LV2_CORE_PREFIX + "ChorusPlugin",
			CombPlugin = LV2_CORE_PREFIX + "CombPlugin",
			CompressorPlugin = LV2_CORE_PREFIX + "CompressorPlugin",
			ConstantPlugin = LV2_CORE_PREFIX + "ConstantPlugin",
			ControlPort = LV2_CORE_PREFIX + "ControlPort",
			ConverterPlugin = LV2_CORE_PREFIX + "ConverterPlugin",
			DelayPlugin = LV2_CORE_PREFIX + "DelayPlugin",
			DistortionPlugin = LV2_CORE_PREFIX + "DistortionPlugin",
			DynamicsPlugin = LV2_CORE_PREFIX + "DynamicsPlugin",
			EQPlugin = LV2_CORE_PREFIX + "EQPlugin",
			EnvelopePlugin = LV2_CORE_PREFIX + "EnvelopePlugin",
			ExpanderPlugin = LV2_CORE_PREFIX + "ExpanderPlugin",
			ExtensionData = LV2_CORE_PREFIX + "ExtensionData",
			Feature = LV2_CORE_PREFIX + "Feature",
			FilterPlugin = LV2_CORE_PREFIX + "FilterPlugin",
			FlangerPlugin = LV2_CORE_PREFIX + "FlangerPlugin",
			FunctionPlugin = LV2_CORE_PREFIX + "FunctionPlugin",
			GatePlugin = LV2_CORE_PREFIX + "GatePlugin",
			GeneratorPlugin = LV2_CORE_PREFIX + "GeneratorPlugin",
			HighpassPlugin = LV2_CORE_PREFIX + "HighpassPlugin",
			InputPort = LV2_CORE_PREFIX + "InputPort",
			InstrumentPlugin = LV2_CORE_PREFIX + "InstrumentPlugin",
			LimiterPlugin = LV2_CORE_PREFIX + "LimiterPlugin",
			LowpassPlugin = LV2_CORE_PREFIX + "LowpassPlugin",
			MixerPlugin = LV2_CORE_PREFIX + "MixerPlugin",
			ModulatorPlugin = LV2_CORE_PREFIX + "ModulatorPlugin",
			MultiEQPlugin = LV2_CORE_PREFIX + "MultiEQPlugin",
			OscillatorPlugin = LV2_CORE_PREFIX + "OscillatorPlugin",
			OutputPort = LV2_CORE_PREFIX + "OutputPort",
			ParaEQPlugin = LV2_CORE_PREFIX + "ParaEQPlugin",
			PhaserPlugin = LV2_CORE_PREFIX + "PhaserPlugin",
			PitchPlugin = LV2_CORE_PREFIX + "PitchPlugin",
			Plugin = LV2_CORE_PREFIX + "Plugin",
			PluginBase = LV2_CORE_PREFIX + "PluginBase",
			Point = LV2_CORE_PREFIX + "Point",
			Port = LV2_CORE_PREFIX + "Port",
			PortProperty = LV2_CORE_PREFIX + "PortProperty",
			Resource = LV2_CORE_PREFIX + "Resource",
			ReverbPlugin = LV2_CORE_PREFIX + "ReverbPlugin",
			ScalePoint = LV2_CORE_PREFIX + "ScalePoint",
			SimulatorPlugin = LV2_CORE_PREFIX + "SimulatorPlugin",
			SpatialPlugin = LV2_CORE_PREFIX + "SpatialPlugin",
			Specification = LV2_CORE_PREFIX + "Specification",
			SpectralPlugin = LV2_CORE_PREFIX + "SpectralPlugin",
			UtilityPlugin = LV2_CORE_PREFIX + "UtilityPlugin",
			WaveshaperPlugin = LV2_CORE_PREFIX + "WaveshaperPlugin";
		
		public static bool IsAudioPort (this Port port) => port.Classes.Any (n => n.AsUri == AudioPort);
		public static bool IsInputPort (this Port port) => port.Classes.Any (n => n.AsUri == InputPort);
		public static bool IsOutputPort (this Port port) => port.Classes.Any (n => n.AsUri == OutputPort);
		public static bool IsControlPort (this Port port) => port.Classes.Any (n => n.AsUri == ControlPort);
		public static bool IsAudioIn (this Port port) => port.IsAudioPort () && port.IsInputPort ();
		public static bool IsAudioOut (this Port port) => port.IsAudioPort () && port.IsOutputPort ();
		public static bool IsControlIn (this Port port) => port.IsControlPort () && port.IsOutputPort ();

	}

	public static class Lv2ExtUris
	{
		public const string LV2UridUri = "http://lv2plug.in/ns/ext/urid";
		const string LV2_CORE_PREFIX = LV2UridUri + "#";
		public const string
			FeatureUridMap = LV2_CORE_PREFIX + "map",
			FeatureUridUnmap = LV2_CORE_PREFIX + "unmap";

		public const string LV2OptionsUri = "http://lv2plug.in/ns/ext/options";
		const string LV2_OPTIONS_PREFIX = LV2OptionsUri + "#";
		public const string
			ClassOptionsOption = LV2_OPTIONS_PREFIX + "Option";

		public const string
			FeatureInterface = LV2_OPTIONS_PREFIX + "interface",
			FeatureOptions = LV2_OPTIONS_PREFIX + "options",
			PropertyOptionsRequiredOption = LV2_OPTIONS_PREFIX + "requiredOption",
			PropertyOptionsSupportedOption = LV2_OPTIONS_PREFIX + "supportedOption";
	}

	public static class Lv2Properties
	{
		const string LV2_CORE_PREFIX = LV2CoreUris.LV2CoreUri + "#";

		public const string
			AppliesTo = LV2_CORE_PREFIX + "appliesTo",
			Binary = LV2_CORE_PREFIX + "binary",
			ConnectionOptional = LV2_CORE_PREFIX + "connectionOptional",
			Control = LV2_CORE_PREFIX + "control",
			Default = LV2_CORE_PREFIX + "default",
			Designation = LV2_CORE_PREFIX + "designation",
			Documentation = LV2_CORE_PREFIX + "documentation",
			Enumeration = LV2_CORE_PREFIX + "enumeration",
			ExtensionData = LV2_CORE_PREFIX + "extensionData",
			FreeWheeling = LV2_CORE_PREFIX + "freeWheeling",
			HardRTCapable = LV2_CORE_PREFIX + "hardRTCapable",
			InPlaceBroken = LV2_CORE_PREFIX + "inPlaceBroken",
			Index = LV2_CORE_PREFIX + "index",
			Integer = LV2_CORE_PREFIX + "integer",
			IsLive = LV2_CORE_PREFIX + "isLive",
			Latency = LV2_CORE_PREFIX + "latency",
			Maximum = LV2_CORE_PREFIX + "maximum",
			MicroVersion = LV2_CORE_PREFIX + "microVersion",
			Minimum = LV2_CORE_PREFIX + "minimum",
			MinorVersion = LV2_CORE_PREFIX + "minorVersion",
			Name = LV2_CORE_PREFIX + "name",
			OptionalFeature = LV2_CORE_PREFIX + "optionalFeature",
			Port = LV2_CORE_PREFIX + "port",
			PortProperty = LV2_CORE_PREFIX + "portProperty",
			Project = LV2_CORE_PREFIX + "project",
			Prototype = LV2_CORE_PREFIX + "prototype",
			ReportsLatency = LV2_CORE_PREFIX + "reportsLatency",
			RequiredFeature = LV2_CORE_PREFIX + "requiredFeature",
			SampleRate = LV2_CORE_PREFIX + "sampleRate",
			ScalePoint = LV2_CORE_PREFIX + "scalePoint",
			Symbol = LV2_CORE_PREFIX + "symbol",
			Toggled = LV2_CORE_PREFIX + "toggled";
	}

	static class PrivateExtensions
	{
		public static string ToManagedString (this IntPtr ptr) => ptr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi (ptr);

		// Use this carefully. The native code might expect that the pointee string alive after the call.
		// For such case, use StringAllocator.AddOrInterned().
		public static void Fixed (this string s, Action<IntPtr> action)
		{
			s.Fixed<int> (p => { action (p); return 0; });
		}

		public static T Fixed<T> (this string s, Func<IntPtr,T> func)
		{
			var ptr = Marshal.StringToHGlobalAnsi (s);
			T ret = func (ptr);
			Marshal.FreeHGlobal (ptr);
			return ret;
		}
	}

	class StringAllocator : IDisposable
	{
		Dictionary<string,IntPtr> handles = new Dictionary<string,IntPtr> ();

		public IntPtr AddOrInterned (string s)
		{
			IntPtr ptr;
			if (handles.TryGetValue (s, out ptr))
				return ptr;
			ptr = Marshal.StringToHGlobalAnsi (s);
			handles [s] = ptr;
			return ptr;
		}

		public void RemoveInterned (string s)
		{
			handles.Remove (s);
		}

		public void Dispose ()
		{
			foreach (var ptr in handles.Values)
				Marshal.FreeHGlobal (ptr);
			handles.Clear ();
		}
	}

	public class World : IDisposable
	{
		StringAllocator allocator;
		IntPtr handle;

		public World ()
		{
			handle = Natives.lilv_world_new ();
		}

		public IntPtr Handle => handle;

		public void Dispose ()
		{
			if (handle != IntPtr.Zero)
				Natives.lilv_world_free (handle);
			allocator.Dispose ();
			allocator = null;
			handle = IntPtr.Zero;
		}
		
		public Node NewUri (string uri) => Node.Get (uri.Fixed (uriPtr => Natives.lilv_new_uri (handle, uriPtr)), true);
		
		public Node NewFileUri (string host, string path) => Node.Get (host.Fixed (hostPtr => path.Fixed (pathPtr => Natives.lilv_new_file_uri (handle, hostPtr, pathPtr))), true);
		
		public Node NewString (string s) => Node.Get (s.Fixed (ptr => Natives.lilv_new_string (handle, ptr)), true);
		
		public Node NewInt (int val) => Node.Get (Natives.lilv_new_int (handle, val), true);
		
		public Node NewFloat (float val) => Node.Get (Natives.lilv_new_float (handle, val), true);
		
		public Node NewBool (bool val) => Node.Get (Natives.lilv_new_bool (handle, val), true);

		public void LoadAll () => Natives.lilv_world_load_all (handle);

		public void LoadBundle (Node bundleUri) => Natives.lilv_world_load_bundle (handle, bundleUri.Handle);

		public void LoadSpecifications () => Natives.lilv_world_load_specifications (handle);

		public void LoadPluginClasses () => Natives.lilv_world_load_plugin_classes (handle);

		public void UnloadBundle (Node bundleUri) => Natives.lilv_world_unload_bundle (handle, bundleUri.Handle);

		public void LoadResource (Node resourceUri) => Natives.lilv_world_load_resource(handle, resourceUri.Handle);

		public void UnloadResource (Node resourceUri) => Natives.lilv_world_unload_resource(handle, resourceUri.Handle);

		public PluginClass PluginClass => PluginClass.Get (Natives.lilv_world_get_plugin_class (handle));
		
		public PluginClasses PluginClasses => new PluginClasses (Natives.lilv_world_get_plugin_classes (handle));
		
		public Plugins AllPlugins => new Plugins (Natives.lilv_world_get_all_plugins (handle), allocator);
		
		public Node GetSymbol (Node subject) => Node.Get (Natives.lilv_world_get_symbol (handle, subject.Handle));

		public Nodes FindNodes (Node subject, Node predicate, Node obj) =>
			new Nodes (Natives.lilv_world_find_nodes (handle, subject.Handle, predicate.Handle, obj.Handle));
		
		public Node Get (Node subject, Node predicate, Node obj) =>
			Node.Get (Natives.lilv_world_get (handle, subject.Handle, predicate.Handle, obj.Handle));
		public bool Ask (Node subject, Node predicate, Node obj) => Natives.lilv_world_ask (handle, subject.Handle, predicate.Handle, obj.Handle);

		public void SetOption (Node subject, string uri, Node value)
		{
			Natives.lilv_world_set_option (handle, allocator.AddOrInterned (uri), value.Handle);
		}

		public State FromWorld (LV2Sharp.URIDFeature map, Node subject) =>
			new State (Natives.lilv_state_new_from_world (handle, map.Handle, subject.Handle), allocator);
		
		public State FromFile (LV2Sharp.URIDFeature map, Node subject, string path) =>
			new State (path.Fixed (ptr => Natives.lilv_state_new_from_file (handle, map.Handle, subject.Handle, ptr)), allocator);
		
		public State FromString (LV2Sharp.URIDFeature map, Node subject, string str) =>
			new State (str.Fixed (ptr => Natives.lilv_state_new_from_file (handle, map.Handle, subject.Handle, ptr)), allocator);

		public void DeleteState (State state) => Natives.lilv_state_delete (handle, state.Handle);

		public State StateFromString (IntPtr map, string str) => State.Get (str.Fixed (strPtr => Natives.lilv_state_new_from_string (handle, map, strPtr)), allocator);
	}
	
	public class LilvEnumerable<T> : IEnumerable<T>, IDisposable
	{
		IntPtr handle;
		Action<IntPtr> on_dispose;
		Func<IntPtr,uint> get_count;
		Func<IntPtr,IEnumerator<T>> create_iterator;
		
		internal LilvEnumerable (IntPtr handle, Action<IntPtr> onDispose, Func<IntPtr,uint> getCount, Func<IntPtr,IEnumerator<T>> createIterator)
		{
			this.handle = handle;
			on_dispose = onDispose;
			get_count = getCount;
			create_iterator = createIterator;
		}

		public void Dispose ()
		{
			on_dispose (handle);
		}
		
		public IntPtr Handle => handle;
		
		public uint Count => get_count (handle);
		
		public IEnumerator<T> GetEnumerator () => create_iterator (handle);
		
		IEnumerator IEnumerable.GetEnumerator () => this.GetEnumerator ();
	}
	
	class LilvIterator<T> : IEnumerator<T>, IEnumerator, IDisposable
		where T : class
	{
		IntPtr collection, iter;
		Func<IntPtr,IntPtr> begin;
		Func<IntPtr,IntPtr,IntPtr> next;
		Func<IntPtr,IntPtr,T> getter;
		Func<IntPtr,IntPtr,bool> is_end;
		T current;
		
		protected LilvIterator (IntPtr collection, Func<IntPtr,IntPtr> begin, Func<IntPtr,IntPtr,IntPtr> next, Func<IntPtr,IntPtr,T> getter, Func<IntPtr,IntPtr,bool> isEnd)
		{
			this.collection = collection;
			this.begin = begin;
			this.next = next;
			this.getter = getter;
			this.is_end = isEnd;
		}
		
		public IntPtr Collection => collection;
		
		public IntPtr Iter => iter;
		
		void IDisposable.Dispose ()
		{
			iter = IntPtr.Zero;
		}
		
		void IEnumerator.Reset ()
		{
			iter = begin (collection);
			current = default (T);
		}
		
		public bool MoveNext ()
		{
			if (iter == IntPtr.Zero)
				iter = begin (collection);
			else if (is_end (collection, iter))
				return false;
			else
				iter = next (collection, iter);
			current = null;
			return iter != IntPtr.Zero;
		}
		
		public T Current => (current = current == null ? getter (collection, iter) : current);
		
		object IEnumerator.Current => this.Current;
	}

	public class PluginClasses : LilvEnumerable<PluginClass>
	{
		public PluginClasses (IntPtr handle)
			: base (handle,
				h => Natives.lilv_plugin_classes_free (h),
				h => Natives.lilv_plugin_classes_size (h),
				h => new Iterator (h))
		{
		}
		
		public PluginClass GetByUri (Node node)
		{
			return PluginClass.Get (Natives.lilv_plugin_classes_get_by_uri (Handle, node.Handle));
		}
		
		class Iterator : LilvIterator<PluginClass>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_plugin_classes_begin,
					Natives.lilv_plugin_classes_next,
					(c,i) => PluginClass.Get (Natives.lilv_plugin_classes_get (c, i)),
					Natives.lilv_plugin_classes_is_end)
			{
			}
		}
	}
	
	public class PluginClass
	{
		internal static PluginClass Get (IntPtr handle) =>
			handle == IntPtr.Zero ? null : new PluginClass (handle);
		
		IntPtr handle;
		
		PluginClass (IntPtr handle)
		{
			this.handle = handle;
		}
		
		internal IntPtr Handle => handle;
		
		public IEnumerable<PluginClass> Children => new PluginClasses (Natives.lilv_plugin_class_get_children (handle));
		
		public Node ParentUri => Node.Get (Natives.lilv_plugin_class_get_parent_uri (handle));
		
		public Node Uri => Node.Get (Natives.lilv_plugin_class_get_uri (handle));
		
		public Node Label => Node.Get (Natives.lilv_plugin_class_get_label (handle));
	}
	
	public enum LiteralType
	{
		None,
		Blank,
		Bool,
		Float,
		Int,
		String,
		Uri
	}
	
	public class Nodes : LilvEnumerable<Node>
	{
		public static Nodes Merge (Nodes nl1, Nodes nl2) => new Nodes (Natives.lilv_nodes_merge (nl1.Handle, nl2.Handle));
		
		internal Nodes (IntPtr handle)
			: base (handle,
				Natives.lilv_nodes_free,
				Natives.lilv_nodes_size,
				h => new Iterator (h))
		{
		}

		public Node First => Node.Get (Natives.lilv_nodes_get_first (Handle));

		public bool Contains (Node value) => Natives.lilv_nodes_contains (Handle, value.Handle);
		
		class Iterator : LilvIterator<Node>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_nodes_begin,
					Natives.lilv_nodes_next,
					(c,i) => Node.Get (Natives.lilv_nodes_get (c, i)),
					Natives.lilv_nodes_is_end)
			{
			}
		}
	}

	public class Node : IDisposable
	{
		public static string UriToPath (string uri) => Marshal.PtrToStringAnsi (uri.Fixed (ptr => Natives.lilv_uri_to_path (ptr)));
		public static string FileUriParse (string uri, string hostName) => Marshal.PtrToStringAnsi (uri.Fixed (uriPtr => hostName.Fixed (hostNamePtr => Natives.lilv_file_uri_parse (uriPtr, hostNamePtr))));
		
		internal static Node Get (IntPtr handle, bool shouldFree = false) => handle == IntPtr.Zero ? null : new Node (handle, shouldFree);
		
		readonly IntPtr handle;
		bool should_free;
		
		Node (IntPtr handle, bool shouldFree = false)
		{
			this.handle = handle;
			this.should_free = shouldFree;
		}
		
		public IntPtr Handle => handle;

		public void Dispose ()
		{
			if (should_free)
				Natives.lilv_node_free (handle);
			should_free = false;
		}

		public Node Duplicate () => new Node (Natives.lilv_node_duplicate (handle), true);
		
		public bool IsBlank => Natives.lilv_node_is_blank (handle);
		public bool IsBool => Natives.lilv_node_is_bool (handle);
		public bool IsFloat => Natives.lilv_node_is_float (handle);
		public bool IsInt => Natives.lilv_node_is_int (handle);
		public bool IsLiteral => Natives.lilv_node_is_literal (handle);
		public bool IsString => Natives.lilv_node_is_string (handle);
		public bool IsUri => Natives.lilv_node_is_uri (handle);

		public IntPtr AsBlank => Natives.lilv_node_as_blank (handle);
		public bool AsBool => Natives.lilv_node_as_bool (handle);
		public double AsFloat => Natives.lilv_node_as_float (handle);
		public int AsInt => Natives.lilv_node_as_int (handle);
		public string AsString => Natives.lilv_node_as_string (handle).ToManagedString ();
		public string AsUri => Natives.lilv_node_as_uri (handle).ToManagedString ();

		public string TurtleToken => Marshal.PtrToStringAnsi (Natives.lilv_node_get_turtle_token (handle));
		
		public LiteralType LiteralType =>
			IsBlank ? LiteralType.Blank :
			IsBool ? LiteralType.Bool :
			IsFloat ? LiteralType.Float :
			IsInt ? LiteralType.Int :
			IsString ? LiteralType.String :
			IsUri ? LiteralType.Uri :
			LiteralType.None;
		
		public object Value => IsUri ? (object) AsUri : IsLiteral ?
			(IsBlank ? AsBlank :
			IsBool ? AsBool :
			IsFloat ? AsFloat :
			IsInt ? AsInt :
			IsString ? (object) AsString : "(unknown literal value)")
			: "(non-literal value)";

		public static bool operator == (Node s1, Node s2)
		{
			if (s1 is null)
				return s2 is null;
			return s1.Equals (s2);
		}

		public static bool operator != (Node s1, Node s2)
		{
			if (s1 is null)
				return ! (s2 is null);
			return !s1.Equals (s2);
		}

		public static bool Equals (Node s1, Node s2)
		{
			return s1 == s2;
		}

		public bool Equals (Node s2)
		{
			return !(s2 is null) && Natives.lilv_node_equals (handle, s2.handle);
		}

		public override bool Equals (object o2)
		{
			return Equals (o2 as Node);
		}

		public override int GetHashCode () => (int) handle;

		public string GetPath (string hostName) => hostName.Fixed (ptr =>
			Marshal.PtrToStringAnsi (Natives.lilv_node_get_path (handle, ptr)));
	}
	

	public class Plugins : LilvEnumerable<Plugin>
	{
		StringAllocator allocator;
		internal Plugins (IntPtr handle, StringAllocator allocator)
			: base (handle,
				h => {},
				Natives.lilv_plugins_size,
				h => new Iterator (h, allocator))
		{
			this.allocator = allocator;
		}
		
		public Plugin GetByUri (Node node)
		{
			return Plugin.Get (Natives.lilv_plugins_get_by_uri (Handle, node.Handle), allocator);
		}
		
		class Iterator : LilvIterator<Plugin>
		{
			public Iterator (IntPtr collection, StringAllocator allocator)
				: base (collection,
					Natives.lilv_plugins_begin,
					Natives.lilv_plugins_next,
					(c,i) => Plugin.Get (Natives.lilv_plugins_get (c, i), allocator),
					Natives.lilv_plugins_is_end)
			{
			}
		}
	}

	public class Plugin
	{
		internal static Plugin Get (IntPtr handle, StringAllocator allocator) => handle == IntPtr.Zero ? null : new Plugin (handle, allocator);
		
		StringAllocator allocator;
		IntPtr handle;
		
		Plugin (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
		}

		internal StringAllocator Allocator => allocator;
		
		internal IntPtr Handle => handle;

		public void Verify () => Natives.lilv_plugin_verify (handle);
		
		public Node Uri => Node.Get (Natives.lilv_plugin_get_uri (handle));
		public Node BundleUri => Node.Get (Natives.lilv_plugin_get_bundle_uri (handle));
		public Nodes DataUris => new Nodes (Natives.lilv_plugin_get_data_uris (handle));
		public Node LibraryUri => Node.Get (Natives.lilv_plugin_get_library_uri (handle));
		public Node Name => Node.Get (Natives.lilv_plugin_get_name (handle));
		public PluginClass Class => PluginClass.Get (Natives.lilv_plugin_get_class (handle));
		public Node GetValue (Node predicate) => Node.Get (Natives.lilv_plugin_get_value (handle, predicate.Handle));
		public Nodes SupportedFeatures => new Nodes (Natives.lilv_plugin_get_supported_features (handle));
		public Nodes RequiredFeatures => new Nodes (Natives.lilv_plugin_get_required_features (handle));
		public Nodes OptionalFeatures => new Nodes (Natives.lilv_plugin_get_optional_features (handle));
		public Node ExtensionData => Node.Get (Natives.lilv_plugin_get_extension_data (handle));

		public bool HasFeature (Node featureUri) => Natives.lilv_plugin_has_feature (handle, featureUri.Handle);
		public bool HasExtensionData (Node uri) => Natives.lilv_plugin_has_extension_data (handle, uri.Handle);

		public uint NumPorts => Natives.lilv_plugin_get_num_ports (handle);

		public void GetPortRangesFloat (out double minValues, out double maxValues, out double defValues)
		{
			double min = 0, max = 0, def = 0;
			unsafe {
				double* minp = &min, maxp = &max, defp = &def;
				Natives.lilv_plugin_get_port_ranges_float (handle, (IntPtr) minp, (IntPtr) maxp, (IntPtr) defp);
			}
			minValues = min;
			maxValues = max;
			defValues = def;
		}

		// TODO: it skips "..." arguments
		public uint NumPortsOfClass (Node class1) => Natives.lilv_plugin_get_num_ports_of_class (handle, class1.Handle);
		
		public bool HasLatency => Natives.lilv_plugin_has_latency (handle);
		public uint LatencyPortIndex => Natives.lilv_plugin_get_latency_port_index (handle);
		public Port GetPortByIndex (uint index) => new Port (handle, Natives.lilv_plugin_get_port_by_index (handle, index));
		public Port GetPortBySymbol (Node symbol) => new Port (handle, Natives.lilv_plugin_get_port_by_symbol (handle, symbol.Handle));
		public Port GetPortByDesignation (Node portClass, Node designation) => new Port (handle, Natives.lilv_plugin_get_port_by_designation (handle, portClass == null ? IntPtr.Zero : portClass.Handle, designation.Handle));
		
		public Node Project => Node.Get (Natives.lilv_plugin_get_project (handle));
		public Node AuthorName => Node.Get (Natives.lilv_plugin_get_author_name (handle));
		public Node AuthorEmail => Node.Get (Natives.lilv_plugin_get_author_email (handle));
		public Node AuthorHomepage => Node.Get (Natives.lilv_plugin_get_author_homepage (handle));
		public bool IsReplaced => Natives.lilv_plugin_is_replaced (handle);
		
		public void WriteDescription (Plugin plugin, Node baseUri, IntPtr file) => Natives.lilv_plugin_write_description (handle, plugin.Handle, baseUri.Handle, file);
		
		public void WriteManifestEntry (Plugin plugin, Node baseUri, IntPtr manifestFile, string pluginFilePath)
		{
			pluginFilePath.Fixed (ptr => Natives.lilv_plugin_write_manifest_entry (handle, plugin.Handle, baseUri.Handle, manifestFile, ptr));
		}
		
		public Nodes GetRelated (Node type) => new Nodes (Natives.lilv_plugin_get_related (handle, type.Handle));


		public UIs UIs => new UIs (Natives.lilv_plugin_get_uis (handle));

		[StructLayout (LayoutKind.Sequential)]
		class LV2_Feature_Marshal
		{
			public IntPtr URI;
			public IntPtr Data;
		}

		public Instance Instantiate (double sampleRate, Feature [] features)
		{
			var gcHandles = new List<GCHandle> ();
			var nativeFeatures = new List<LV2_Feature_Marshal> ();
			var hGlobals = new List<IntPtr> ();
			foreach (var f in features) {
				var uriPtr = Marshal.StringToHGlobalAnsi (f.URI);
				hGlobals.Add (uriPtr);
				Console.Error.WriteLine ($"  argument feature URI: {f?.URI} of type {f?.Data?.GetType ()} ({f?.Data?.Handle})");
				var nf = new LV2_Feature_Marshal { Data = f.Data == null ? IntPtr.Zero : f.Data.Handle, URI = uriPtr };
				nativeFeatures.Add (nf);
			}
			nativeFeatures.Add (null); // NULL terminator

			var nfArray = nativeFeatures.ToArray ();
			var nfHandle = GCHandle.Alloc (nfArray, GCHandleType.Pinned);
			try {
				var nfPtr = nfHandle.AddrOfPinnedObject ();
				for (IntPtr p = nfPtr; Marshal.ReadIntPtr (p) != IntPtr.Zero; p += Marshal.SizeOf<IntPtr> ()) {
					Console.Error.WriteLine ("PTR: " + p);
					var v = Marshal.PtrToStructure<LV2_Feature_Marshal> (Marshal.ReadIntPtr (p));
					Console.Error.WriteLine ("    -- " + v.URI);
					Console.Error.WriteLine ("    -- " + v.Data);
				}
				return Instance.Get (
					Natives.lilv_plugin_instantiate (handle, sampleRate, nfPtr),
					allocator);
			} finally {
				nfHandle.Free ();
				foreach (var gch in gcHandles)
					gch.Free ();
				foreach (var hg in hGlobals)
					Marshal.FreeHGlobal (hg);
			}
		}
	}
	
	public class Port
	{
		IntPtr plugin;
		IntPtr port;
		
		internal Port (IntPtr plugin, IntPtr port)
		{
			if (plugin == IntPtr.Zero)
				throw new ArgumentNullException (nameof (plugin));
			if (port == IntPtr.Zero)
				throw new ArgumentNullException (nameof (port));
			
			this.plugin = plugin;
			this.port = port;
		}
		
		internal IntPtr PluginHandle => plugin;
		internal IntPtr PortHandle => port;
		
		public Node Node => Node.Get (Natives.lilv_port_get_node (plugin, port));

		public Nodes GetValue (Node predicate) => new Nodes (Natives.lilv_port_get_value (plugin, port, predicate.Handle));

		public Node Get (Node predicate) => Node.Get (Natives.lilv_port_get (plugin, port, predicate.Handle));
		
		public Nodes Properties => new Nodes (Natives.lilv_port_get_properties (plugin, port));
		
		public bool HasProperty (Node propertyUri) => Natives.lilv_port_has_property (plugin, port, propertyUri.Handle);
		
		public bool SupportsEvent (Node eventType) => Natives.lilv_port_supports_event (plugin, port, eventType.Handle);

		public uint Index => Natives.lilv_port_get_index (plugin, port);
		public Node Symbol => Node.Get (Natives.lilv_port_get_symbol (plugin, port));
		public Node Name => Node.Get (Natives.lilv_port_get_name (plugin, port));
		public Nodes Classes => new Nodes (Natives.lilv_port_get_classes (plugin, port));

		public bool Is (Node portClass) => Natives.lilv_port_is_a (plugin, port, portClass.Handle);

		public void GetRange (out Node deflt, out Node minimum, out Node maximum)
		{
			IntPtr min = IntPtr.Zero, max = IntPtr.Zero, def = IntPtr.Zero;
			unsafe {
				IntPtr* minp = &min, maxp = &max, defp = &def;
				Natives.lilv_port_get_range (plugin, port, (IntPtr) defp, (IntPtr) minp, (IntPtr) maxp);
			}
			deflt = Node.Get (def);
			minimum = Node.Get (min);
			maximum = Node.Get (max);
		}
		
		public ScalePoints ScalePoints => new ScalePoints (Natives.lilv_port_get_scale_points (plugin, port));
	}

	public class ScalePoints : LilvEnumerable<ScalePoint>
	{
		public ScalePoints (IntPtr handle)
			: base (handle,
				Natives.lilv_scale_points_free,
				Natives.lilv_scale_points_size,
				h => new Iterator (h))
		{
		}
		
		class Iterator : LilvIterator<ScalePoint>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_scale_points_begin,
					Natives.lilv_scale_points_next,
					(c,i) => new ScalePoint (Natives.lilv_scale_points_get (c, i)),
					Natives.lilv_scale_points_is_end)
			{
			}
		}
	}
	
	public class ScalePoint
	{
		IntPtr handle;
		
		public ScalePoint (IntPtr handle)
		{
			this.handle = handle;
		}
		
		internal IntPtr Handle => handle;
		
		public Node Label => Node.Get (Natives.lilv_scale_point_get_label (handle));

		public Node Value => Node.Get (Natives.lilv_scale_point_get_value (handle));
	}

	public class UIs : LilvEnumerable<UI>
	{
		public UIs (IntPtr handle)
			: base (handle, Natives.lilv_uis_free, Natives.lilv_uis_size, h => new Iterator (h))
		{
		}

		public UI GetByUri (Node uri) => UI.Get (Natives.lilv_uis_get_by_uri (Handle, uri.Handle));
		
		class Iterator : LilvIterator<UI>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_uis_begin,
					Natives.lilv_uis_next,
					(c,i) => new UI (Natives.lilv_uis_get(c, i)),
					Natives.lilv_uis_is_end)
			{
			}
		}
	}

	public class UI
	{
		internal static UI Get (IntPtr handle) => handle == IntPtr.Zero ? null : new UI (handle);
		
		IntPtr handle;
		
		internal UI (IntPtr handle)
		{
			this.handle = handle;
		}
		
		public Node Uri => Node.Get (Natives.lilv_ui_get_uri (handle));
		public Nodes Classes => new Nodes (Natives.lilv_ui_get_classes (handle));
		public Node BundleUri => Node.Get (Natives.lilv_ui_get_bundle_uri (handle));
		public Node BinaryUri => Node.Get (Natives.lilv_ui_get_binary_uri (handle));

		public bool Is (Node classUri) => Natives.lilv_ui_is_a (handle, classUri.Handle);
		
		public bool IsSupported (UISupportedFunc func, Node containerType, out Node uiType)
		{
			uint Cb (IntPtr containerTypeUri, IntPtr uiTypeUri)
			{
				// It is not expected to crash within native call.
				try {
					return func (Node.Get (containerTypeUri), Node.Get (uiTypeUri));
				}
				catch {
					return 0;
				}
			}

			IntPtr ptr = IntPtr.Zero;
			unsafe {
				void* rptr = &ptr;
				var ret = Natives.lilv_ui_is_supported (handle, Cb, containerType.Handle, (IntPtr) rptr);
				uiType = Node.Get (ptr);
				return ret != 0;
			}
		}
	}

	public delegate uint UISupportedFunc (Node containerTypeUri, Node uiTypeUri);

	public delegate IntPtr GetPortValueFunc (IntPtr portSymbol, IntPtr userData, IntPtr size, IntPtr type);

	public class State
	{
		internal static State Get (IntPtr handle, StringAllocator allocator) => handle == IntPtr.Zero ? null : new State (handle, allocator);
		
		StringAllocator allocator;

		public static State FromInstance (Plugin plugin, Instance instance, LV2Sharp.URIDFeature map,
			string fileDir, string copyDir, string linkDir, string saveDir, GetPortValueFunc getValue,
			IntPtr userData, uint flags, Feature [] features)
		{
			var gch = GCHandle.Alloc (features);
			try {
				var featuresPtr = Marshal.UnsafeAddrOfPinnedArrayElement (features, 0);
				return fileDir.Fixed (fileDirPtr =>
					copyDir.Fixed (copyDirPtr =>
						linkDir.Fixed (linkDirPtr =>
							saveDir.Fixed (saveDirPtr =>
								new State (
									Natives.lilv_state_new_from_instance (
										plugin.Handle, instance.Handle,
										map.Handle, fileDirPtr, copyDirPtr,
										linkDirPtr, saveDirPtr,
										(p1, p2, p3, p4) =>
											getValue (p1, p2, p3, p4),
										userData, flags,
										featuresPtr), plugin.Allocator)))));
			} finally {
				gch.Free ();
			}
		}
		
		readonly IntPtr handle;
		
		internal State (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
		}

		internal IntPtr Handle => handle;

		public void Dispose ()
		{
			Natives.lilv_state_free (handle);
		}

		public static bool operator == (State s1, State s2)
		{
			if (s1 is null)
				return s2 is null;
			return s1.Equals (s2);
		}

		public static bool operator != (State s1, State s2)
		{
			if (s1 is null)
				return ! (s2 is null);
			return !s1.Equals (s2);
		}

		public static bool Equals (State s1, State s2)
		{
			return s1 == s2;
		}

		public bool Equals (State s2)
		{
			return !(s2 is null) && Natives.lilv_state_equals (handle, s2.handle);
		}

		public override bool Equals (object o2)
		{
			return Equals (o2 as State);
		}

		public override int GetHashCode () => (int) handle;

		public uint NumProperties => Natives.lilv_state_get_num_properties (handle);

		public Node PluginUri => Node.Get (Natives.lilv_state_get_plugin_uri (handle));

		public Node Uri => Node.Get (Natives.lilv_state_get_uri (handle));

		public string Label {
			get => Natives.lilv_state_get_label (handle).ToManagedString ();
			set => Natives.lilv_state_set_label (handle, allocator.AddOrInterned (value));
		}

		public int SetMetadata (uint key, IntPtr value, int size, uint type, uint flags) =>
			Natives.lilv_state_set_metadata (handle, key, value, new IntPtr (size), type, flags);

		public void EmitPortValues (SetPortValueFunc setter, IntPtr userData) =>
			Natives.lilv_state_emit_port_values (handle, (p1, p2, p3, p4, p5) => setter (p1, p2, p3, (int) p4, p5), userData);

		public void Restore (Instance instance, SetPortValueFunc setter, IntPtr userData, uint flags, Feature [] features)
		{
			var gch = GCHandle.Alloc (features);
			try {
				var featuresPtr = Marshal.UnsafeAddrOfPinnedArrayElement (features, 0);
				Natives.lilv_state_restore (handle, instance.Handle,
					(p1, p2, p3, p4, p5) => setter (p1, p2, p3, (int) p4, p5), userData, flags,
					featuresPtr);
			} finally {
				gch.Free ();
			}
		}

		public void Save (World world, LV2Sharp.URIDFeature map, LV2Sharp.URIDFeature unmap, string uri, string dir,
			string filename) =>
			uri.Fixed (uriPtr => dir.Fixed (dirPtr => filename.Fixed (filenamePtr =>
				Natives.lilv_state_save (world.Handle, map.Handle, unmap.Handle, handle, uriPtr, dirPtr,
					filenamePtr))));

		public string StateToString (World world, LV2Sharp.URIDFeature map, LV2Sharp.URIDFeature unmap, string uri,
			string baseUri) => uri.Fixed (uriPtr => baseUri.Fixed (baseUriPtr =>
			Natives.lilv_state_to_string (world.Handle, map.Handle, unmap.Handle, handle,
				uriPtr, baseUriPtr))).ToManagedString ();
	}

	public delegate void SetPortValueFunc (IntPtr portSymbol, IntPtr userData, IntPtr value, int size, uint type);

	[StructLayout (LayoutKind.Sequential)]
	struct LilvInstanceImpl
	{
		public readonly IntPtr Lv2Descriptor;
		public readonly IntPtr Lv2Handle;
		public readonly IntPtr Impl;
	}
	
	public class Instance
	{
		internal static Instance Get (IntPtr handle, StringAllocator allocator) =>
			handle == IntPtr.Zero ? null : new Instance (handle, allocator);
		
		readonly StringAllocator allocator;
		readonly IntPtr handle;
		
		internal Instance (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
			impl = Marshal.PtrToStructure<LilvInstanceImpl> (handle);
			descriptor = Marshal.PtrToStructure<LV2Sharp.LV2Descriptor> (impl.Lv2Descriptor);
		}

		internal IntPtr Handle => handle;

		public void Dispose () => Natives.lilv_instance_free (handle);

		readonly LilvInstanceImpl impl;
		readonly LV2Sharp.LV2Descriptor descriptor;

		// This is inline.
		//public string Uri => Natives.lilv_instance_get_uri (handle).ToManagedString ();
		public string Uri => Marshal.PtrToStringAnsi (descriptor.URI);

		// This is inline.
		//public void ConnectPort (uint portIndex, IntPtr dataLocation) => Natives.lilv_instance_connect_port (handle, portIndex, dataLocation);
		LV2Sharp.Lv2DescriptorConnectPort connect_port => Marshal.GetDelegateForFunctionPointer<LV2Sharp.Lv2DescriptorConnectPort> (descriptor.ConnectPort);
		public void ConnectPort (uint portIndex, IntPtr dataLocation) => connect_port (impl.Lv2Handle, portIndex, dataLocation);

		// This is inline.
		//public void Activate () => Natives.lilv_instance_activate (handle);
		LV2Sharp.Lv2DescriptorActivate activate => Marshal.GetDelegateForFunctionPointer<LV2Sharp.Lv2DescriptorActivate> (descriptor.Activate);
		public void Activate ()
		{
			if (descriptor.Activate != IntPtr.Zero)
				activate (impl.Lv2Handle);
		}

		// This is inline.
		//public void Run (uint sampleCount) => Natives.lilv_instance_run (handle, sampleCount);
		LV2Sharp.Lv2DescriptorRun run => Marshal.GetDelegateForFunctionPointer<LV2Sharp.Lv2DescriptorRun> (descriptor.Run);
		public void Run (uint sampleCount) => run (impl.Lv2Handle, sampleCount);

		// This is inline.
		//public void Deactivate () => Natives.lilv_instance_deactivate (handle);
		LV2Sharp.Lv2DescriptorDeactivate deactivate => Marshal.GetDelegateForFunctionPointer<LV2Sharp.Lv2DescriptorDeactivate> (descriptor.Deactivate);

		public void Deactivate ()
		{
			if (descriptor.Deactivate != IntPtr.Zero)
				deactivate (impl.Lv2Handle);
		}

		// This is inline.
		//public IntPtr GetExtensionData (string uri) => uri.Fixed (uriPtr => Natives.lilv_instance_get_extension_data (handle, uriPtr));
		LV2Sharp.Lv2DescriptorExtensionData extension_data => Marshal.GetDelegateForFunctionPointer<LV2Sharp.Lv2DescriptorExtensionData> (descriptor.ExtensionData);
		public void GetExtensionData (string uri) => Node.Get (uri.Fixed (uriPtr => extension_data (impl.Lv2Handle, uriPtr)));

		// This is inline.
		//LV2Sharp.Descriptor Descriptor => new LV2Sharp.Descriptor (Natives.lilv_instance_get_descriptor (handle));

		// This is inline.
		//LV2Sharp.LV2Handle LV2Handle => new LV2Sharp.LV2Handle (Natives.lilv_instance_get_handle (handle));
		public IntPtr LV2Handle => impl.Lv2Handle;
	}
}

// These are manually bound structures for LV2 and lv2core extensions.
namespace LV2Sharp
{
	delegate void Lv2DescriptorConnectPort (IntPtr lv2Handle, uint portIndex, IntPtr dataLocation);
	delegate void Lv2DescriptorActivate (IntPtr lv2Handle);
	delegate void Lv2DescriptorRun (IntPtr lv2Handle, uint sampleCount);
	delegate void Lv2DescriptorDeactivate (IntPtr lv2Handle);
	delegate IntPtr Lv2DescriptorExtensionData (IntPtr lv2Handle, IntPtr uri);
	
	[StructLayout (LayoutKind.Sequential)]
	struct LV2Descriptor
	{
		public readonly IntPtr URI;
		public readonly IntPtr Instantiate;
		public readonly IntPtr ConnectPort;
		public readonly IntPtr Activate;
		public readonly IntPtr Run;
		public readonly IntPtr Deactivate;
		public readonly IntPtr Cleanup;
		public readonly IntPtr ExtensionData;
	}

	// managed object, no need to care about marshaling. We use LV2_Feature for that.
	public class Feature
	{
		public string URI { get; set; }
		public Lv2FeatureData Data { get; set; }
	}

	struct LV2UIDescriptor
	{
		public readonly IntPtr URI;
		public readonly IntPtr Instantiate;
		public readonly IntPtr Cleanup;
		public readonly IntPtr PortEvent;
		public readonly IntPtr ExtensionData;
	}

	/*
	struct LV2UIResize
	{
		public readonly IntPtr Handle;
		public readonly IntPtr UIResize;
	}

	struct LV2UIPortMap
	{
		public readonly IntPtr Handle;
		public readonly IntPtr PortIndex;
	}

	struct LV2UIPortSubscribe
	{
		public readonly IntPtr Handle;
		public readonly IntPtr PortSubscribe;
		public readonly IntPtr PortUnsubscribe;
	}

	struct LV2UITouch
	{
		public readonly IntPtr Handle;
		public readonly IntPtr Touch;
	}	

	struct LV2UIIdleInterface
	{
		public readonly IntPtr IdleInterface;
	}

	struct LV2UIShowInterface
	{
		public readonly IntPtr Show;
		public readonly IntPtr Hide;
	}

	struct LV2UIPeakData
	{
		public readonly uint PeriodStart;
		public readonly uint PeriodSize;
		public readonly float Peak;
	}
	*/

	public abstract class Lv2FeatureData : IDisposable
	{
		public virtual void Dispose ()
		{
			gch.Free ();
		}

		protected void Pin (Array o)
		{
			gch = GCHandle.Alloc (o, GCHandleType.Pinned);
			handle = Marshal.UnsafeAddrOfPinnedArrayElement (o, 0);
		}
		
		protected void Pin (object o)
		{
			gch = GCHandle.Alloc (o, GCHandleType.Pinned);
			handle = gch.AddrOfPinnedObject ();
		}

		GCHandle gch;

		IntPtr handle;
		public IntPtr Handle => handle;
	}
	
	// used for both map and unmap
	public class URIDFeature : Lv2FeatureData
	{
		public delegate uint Map (IntPtr handle, string uri);

		GCHandle delegate_pin;
		
		[StructLayout (LayoutKind.Sequential)]
		class URIDMapMarshal
		{
			public IntPtr Handle;
			public Delegates.delegate9 Map;
		}
		
		public URIDFeature (Map map)
		{
			Delegates.delegate9 _map = (handle, uri) => map (handle, Marshal.PtrToStringAnsi (uri));
			delegate_pin = GCHandle.Alloc (_map);
			
			/*
			var a = new LV2_URID_Map [] {
				new LV2_URID_Map {
					handle = IntPtr.Zero,
					map = _map
				}
			};
			Pin (a);
			*/
			Pin (new URIDMapMarshal { Handle = new IntPtr (GetHashCode ()), Map = _map });
		}

		public override void Dispose ()
		{
			delegate_pin.Free ();
			base.Dispose ();
		}
	}

	public class OptionFeature : Lv2FeatureData
	{
		public OptionFeature (int/*LV2_Options_Context*/ context, uint subject, uint/*LV2_Atom_URID*/ key, uint size, uint/*LV2_Atom_URID*/ type, IntPtr value)
		{
			var a = new [] {
				new LV2_Options_Option {
					context = (LV2_Options_Context) context,
					subject = subject,
					key = key,
					size = size,
					type = type,
					value = value
				}
			};
			Pin (a);
		}
	}
}
