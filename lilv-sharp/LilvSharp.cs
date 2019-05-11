using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LilvSharp.NativeInterop;

namespace LilvSharp
{
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

		public void LoadAll () => Natives.lilv_world_load_all (handle);

		public void LoadBundle (Node bundleUri) => Natives.lilv_world_load_bundle (handle, bundleUri.Handle);

		public void LoadSpecifications () => Natives.lilv_world_load_specifications (handle);

		public void LoadPluginClasses () => Natives.lilv_world_load_plugin_classes (handle);

		public void UnloadBundle (Node bundleUri) => Natives.lilv_world_unload_bundle (handle, bundleUri.Handle);

		public void LoadResource (Node resourceUri) => Natives.lilv_world_load_resource(handle, resourceUri.Handle);

		public void UnloadResource (Node resourceUri) => Natives.lilv_world_unload_resource(handle, resourceUri.Handle);

		public PluginClasses GetPluginClasses () => new PluginClasses (Natives.lilv_world_get_plugin_classes (handle));
		
		public Plugins GetAllPlugins () => new Plugins (Natives.lilv_world_get_all_plugins (handle), allocator);
		
		public Node GetSymbol (Node subject) => new Node (Natives.lilv_world_get_symbol (handle, subject.Handle));

		public Nodes FindNodes (Node subject, Node predicate, Node obj) =>
			new Nodes (Natives.lilv_world_find_nodes (handle, subject.Handle, predicate.Handle, obj.Handle));
		
		public Node Get (Node subject, Node predicate, Node obj) =>
			new Node (Natives.lilv_world_get (handle, subject.Handle, predicate.Handle, obj.Handle));
		public bool Ask (Node subject, Node predicate, Node obj) => Natives.lilv_world_ask (handle, subject.Handle, predicate.Handle, obj.Handle);

		public void SetOption (Node subject, string uri, Node value)
		{
			Natives.lilv_world_set_option (handle, allocator.AddOrInterned (uri), value.Handle);
		}

		public State FromWorld (LV2Sharp.URIDMap map, Node subject) =>
			new State (Natives.lilv_state_new_from_world (handle, map.Handle, subject.Handle), allocator);
		
		public State FromFile (LV2Sharp.URIDMap map, Node subject, string path) =>
			new State (path.Fixed (ptr => Natives.lilv_state_new_from_file (handle, map.Handle, subject.Handle, ptr)), allocator);
		
		public State FromString (LV2Sharp.URIDMap map, Node subject, string str) =>
			new State (str.Fixed (ptr => Natives.lilv_state_new_from_file (handle, map.Handle, subject.Handle, ptr)), allocator);

		public void DeleteState (State state) => Natives.lilv_state_delete (handle, state.Handle);
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
		
		public PluginClass GetPluginByUri (Node node)
		{
			return new PluginClass (Natives.lilv_plugin_classes_get_by_uri (Handle, node.Handle));
		}
		
		class Iterator : LilvIterator<PluginClass>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_plugin_classes_begin,
					Natives.lilv_plugin_classes_next,
					(c,i) => new PluginClass (Natives.lilv_plugin_classes_get (c, i)),
					Natives.lilv_plugin_classes_is_end)
			{
			}
		}
	}
	
	public class PluginClass
	{
		IntPtr handle;
		
		public PluginClass (IntPtr handle)
		{
			this.handle = handle;
		}
		
		public IntPtr Handle => handle;
		
		public IEnumerable<PluginClass> Children => new PluginClasses (Natives.lilv_plugin_class_get_children (handle));
		
		public Node ParentUri => new Node (Natives.lilv_plugin_class_get_parent_uri (handle));
		
		public Node Uri => new Node (Natives.lilv_plugin_class_get_uri (handle));
		
		public Node Label => new Node (Natives.lilv_plugin_class_get_label (handle));
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
		public Nodes (IntPtr handle)
			: base (handle,
				Natives.lilv_nodes_free,
				Natives.lilv_nodes_size,
				h => new Iterator (h))
		{
		}
		
		class Iterator : LilvIterator<Node>
		{
			public Iterator (IntPtr collection)
				: base (collection,
					Natives.lilv_nodes_begin,
					Natives.lilv_nodes_next,
					(c,i) => new Node (Natives.lilv_nodes_get (c, i)),
					Natives.lilv_nodes_is_end)
			{
			}
		}
	}

	public class Node
	{
		IntPtr handle;
		
		public Node (IntPtr handle)
		{
			this.handle = handle;
		}
		
		public IntPtr Handle => handle;
		
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
		
		public LiteralType LiteralType =>
			IsBlank ? LiteralType.Blank :
			IsBool ? LiteralType.Bool :
			IsFloat ? LiteralType.Float :
			IsInt ? LiteralType.Int :
			IsString ? LiteralType.String :
			IsUri ? LiteralType.Uri :
			LiteralType.None;
		
		public object Value => IsLiteral ?
			(IsBlank ? (object) AsBlank :
			IsBool ? AsBool :
			IsFloat ? AsFloat :
			IsInt ? AsInt :
			IsString ? AsString :
			IsUri ? (object) AsUri : "(unknown literal value)") : "(non-literal value)";
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
		
		class Iterator : LilvIterator<Plugin>
		{
			public Iterator (IntPtr collection, StringAllocator allocator)
				: base (collection,
					Natives.lilv_plugins_begin,
					Natives.lilv_plugins_next,
					(c,i) => new Plugin (Natives.lilv_plugins_get (c, i), allocator),
					Natives.lilv_plugins_is_end)
			{
			}
		}
	}

	public class Plugin
	{
		StringAllocator allocator;
		IntPtr handle;
		
		internal Plugin (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
		}

		internal StringAllocator Allocator => allocator;
		
		public IntPtr Handle => handle;
		
		public Node Uri => new Node (Natives.lilv_plugin_get_uri (handle));
		public Node BundleUri => new Node (Natives.lilv_plugin_get_bundle_uri (handle));
		public Nodes DataUris => new Nodes (Natives.lilv_plugin_get_data_uris (handle));
		public Node LibraryUri => new Node (Natives.lilv_plugin_get_library_uri (handle));
		public Node Name => new Node (Natives.lilv_plugin_get_name (handle));
		public PluginClass Class => new PluginClass (Natives.lilv_plugin_get_class (handle));
		public Node Value => new Node (Natives.lilv_plugin_get_name (handle));
		public Nodes SupportedFeatures => new Nodes (Natives.lilv_plugin_get_supported_features (handle));
		public Nodes RequiredFeatures => new Nodes (Natives.lilv_plugin_get_required_features (handle));
		public Nodes OptionalFeatures => new Nodes (Natives.lilv_plugin_get_optional_features (handle));
		public Node ExtensionData => new Node (Natives.lilv_plugin_get_extension_data (handle));

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
		public Port GetPortByDesignation (Node portClass, Node designation) => new Port (handle, Natives.lilv_plugin_get_port_by_designation (handle, portClass.Handle, designation.Handle));
		
		public Node Project => new Node (Natives.lilv_plugin_get_project (handle));
		public Node AuthorName => new Node (Natives.lilv_plugin_get_author_name (handle));
		public Node AuthorEmail => new Node (Natives.lilv_plugin_get_author_email (handle));
		public Node AuthorHomepage => new Node (Natives.lilv_plugin_get_author_homepage (handle));
		public bool IsReplaced => Natives.lilv_plugin_is_replaced (handle);
		
		public void WriteDescription (Plugin plugin, Node baseUri, IntPtr file) => Natives.lilv_plugin_write_description (handle, plugin.Handle, baseUri.Handle, file);
		
		public void WriteManifestEntry (Plugin plugin, Node baseUri, IntPtr manifestFile, string pluginFilePath)
		{
			pluginFilePath.Fixed (ptr => Natives.lilv_plugin_write_manifest_entry (handle, plugin.Handle, baseUri.Handle, manifestFile, ptr));
		}
		
		public Nodes GetRelated (Node type) => new Nodes (Natives.lilv_plugin_get_related (handle, type.Handle));


		public UIs UIs => new UIs (Natives.lilv_plugin_get_uis (handle));

		public Instance Instantiate (double sampleRate, LV2Sharp.Feature features) =>
			new Instance (Natives.lilv_plugin_instantiate (handle, sampleRate, features.Handle), allocator);
	}
	
	public class Port
	{
		IntPtr plugin;
		IntPtr port;
		
		internal Port (IntPtr plugin, IntPtr port)
		{
			this.plugin = plugin;
			this.port = port;
		}
		
		public IntPtr PluginHandle => plugin;
		public IntPtr PortHandle => port;
		
		public Node Node => new Node (Natives.lilv_port_get_node (plugin, port));

		public Nodes GetValue (Node predicate) => new Nodes (Natives.lilv_port_get_value (plugin, port, predicate.Handle));

		public Node Get (Node predicate) => new Node (Natives.lilv_port_get (plugin, port, predicate.Handle));
		
		public Nodes Properties => new Nodes (Natives.lilv_port_get_properties (plugin, port));
		
		public bool HasProperty (Node propertyUri) => Natives.lilv_port_has_property (plugin, port, propertyUri.Handle);
		
		public bool SupportsEvent (Node eventType) => Natives.lilv_port_supports_event (plugin, port, eventType.Handle);

		public uint Index => Natives.lilv_port_get_index (plugin, port);
		public Node Symbol => new Node (Natives.lilv_port_get_symbol (plugin, port));
		public Node Name => new Node (Natives.lilv_port_get_name (plugin, port));
		public Nodes Classes => new Nodes (Natives.lilv_port_get_classes (plugin, port));

		public bool Is (Node portClass) => Natives.lilv_port_is_a (plugin, port, portClass.Handle);

		public void GetRange (out Node deflt, out Node minimum, out Node maximum)
		{
			IntPtr min = IntPtr.Zero, max = IntPtr.Zero, def = IntPtr.Zero;
			unsafe {
				IntPtr* minp = &min, maxp = &max, defp = &def;
				Natives.lilv_port_get_range (plugin, port, (IntPtr) defp, (IntPtr) minp, (IntPtr) maxp);
			}
			deflt = new Node (def);
			minimum = new Node (min);
			maximum = new Node (max);
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
		
		public IntPtr Handle => handle;
		
		public Node Label => new Node (Natives.lilv_scale_point_get_label (handle));

		public Node Value => new Node (Natives.lilv_scale_point_get_value (handle));
	}

	public class UIs : LilvEnumerable<UI>
	{
		public UIs (IntPtr handle)
			: base (handle, Natives.lilv_uis_free, Natives.lilv_uis_size, h => new Iterator (h))
		{
		}
		
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
		IntPtr handle;
		
		internal UI (IntPtr handle)
		{
			this.handle = handle;
		}
		
		public Node Uri => new Node (Natives.lilv_ui_get_uri (handle));
		public Nodes Classes => new Nodes (Natives.lilv_ui_get_classes (handle));
		public Node BundleUri => new Node (Natives.lilv_ui_get_bundle_uri (handle));
		public Node BinaryUri => new Node (Natives.lilv_ui_get_binary_uri (handle));

		public bool Is (Node classUri) => Natives.lilv_ui_is_a (handle, classUri.Handle);
		
		public bool IsSupported (UISupportedFunc func, Node containerType, out Node uiType)
		{
			uint Cb (IntPtr containerTypeUri, IntPtr uiTypeUri)
			{
				// It is not expected to crash within native call.
				try {
					return func (new Node (containerTypeUri), new Node (uiTypeUri));
				}
				catch {
					return 0;
				}
			}

			IntPtr ptr = IntPtr.Zero;
			unsafe {
				void* rptr = &ptr;
				var ret = Natives.lilv_ui_is_supported (handle, Cb, containerType.Handle, (IntPtr) rptr);
				uiType = new Node (ptr);
				return ret != 0;
			}
		}
	}

	public delegate uint UISupportedFunc (Node containerTypeUri, Node uiTypeUri);

	public delegate IntPtr GetPortValueFunc (IntPtr portSymbol, IntPtr userData, IntPtr size, IntPtr type);

	public class State
	{
		StringAllocator allocator;
		
		public static State FromInstance (Plugin plugin, Instance instance, LV2Sharp.URIDMap map, string fileDir, string copyDir, string linkDir, string saveDir, GetPortValueFunc getValue, IntPtr userData, uint flags, LV2Sharp.Feature features) =>
			new State (fileDir.Fixed (fileDirPtr => copyDir.Fixed (copyDirPtr => linkDir.Fixed (linkDirPtr => saveDir.Fixed<IntPtr> (saveDirPtr => Natives.lilv_state_new_from_instance (plugin.Handle, instance.Handle, map.Handle, fileDirPtr, copyDirPtr, linkDirPtr, saveDirPtr, (p1,p2,p3,p4) => getValue (p1,p2,p3,p4), userData, flags, features.Handle))))), plugin.Allocator);
		
		readonly IntPtr handle;
		
		internal State (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
		}

		public IntPtr Handle => handle;

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

		public Node PluginUri => new Node (Natives.lilv_state_get_plugin_uri (handle));

		public Node Uri => new Node (Natives.lilv_state_get_uri (handle));

		public string Label {
			get => Marshal.PtrToStringAnsi (Natives.lilv_state_get_label (handle));
			set => Natives.lilv_state_set_label (handle, allocator.AddOrInterned (value));
		}

		public int SetMetadata (uint key, IntPtr value, int size, uint type, uint flags) =>
			Natives.lilv_state_set_metadata (handle, key, value, new IntPtr (size), type, flags);

		public void EmitPortValues (SetPortValueFunc setter, IntPtr userData) =>
			Natives.lilv_state_emit_port_values (handle, (p1, p2, p3, p4, p5) => setter (p1, p2, p3, (int) p4, p5), userData);

		public void Restore (Instance instance, SetPortValueFunc setter, IntPtr userData, uint flags, LV2Sharp.Feature feature) =>
			Natives.lilv_state_restore (handle, instance.Handle,
				(p1, p2, p3, p4, p5) => setter (p1, p2, p3, (int) p4, p5), userData, flags, feature.Handle);

		public void Save (World world, LV2Sharp.URIDMap map, LV2Sharp.URIDUnmap unmap, string uri, string dir,
			string filename) =>
			uri.Fixed (uriPtr => dir.Fixed (dirPtr => filename.Fixed (filenamePtr =>
				Natives.lilv_state_save (world.Handle, map.Handle, unmap.Handle, handle, uriPtr, dirPtr,
					filenamePtr))));

		public string StateToString (World world, LV2Sharp.URIDMap map, LV2Sharp.URIDUnmap unmap, string uri,
			string baseUri) => Marshal.PtrToStringAnsi (uri.Fixed (uriPtr => baseUri.Fixed (baseUriPtr =>
			Natives.lilv_state_to_string (world.Handle, map.Handle, unmap.Handle, handle,
				uriPtr, baseUriPtr))));
	}

	public delegate void SetPortValueFunc (IntPtr portSymbol, IntPtr userData, IntPtr value, int size, uint type);

	public class Instance
	{
		StringAllocator allocator;
		IntPtr handle;
		
		internal Instance (IntPtr handle, StringAllocator allocator)
		{
			this.handle = handle;
			this.allocator = allocator;
		}

		public IntPtr Handle => handle;

		public void Dispose () => Natives.lilv_instance_free (handle);

		// This is inline.
		//public string Uri => Marshal.PtrToStringAnsi (Natives.lilv_instance_get_uri (handle));

		// This is inline.
		//public void ConnectPort (uint portIndex, IntPtr dataLocation) => Natives.lilv_instance_connect_port (handle, portIndex, dataLocation);

		// This is inline.
		//public void Activate () => Natives.lilv_instance_activate (handle);

		// This is inline.
		//public void Run (uint sampleCount) => Natives.lilv_instance_run (handle, sampleCount);

		// This is inline.
		//public void Deactivate () => Natives.lilv_instance_deactivate (handle);

		// This is inline.
		//public IntPtr GetExtensionData (string uri) => uri.Fixed (uriPtr => Natives.lilv_instance_get_extension_data (handle, uriPtr));

		// This is inline.
		//LV2Sharp.Descriptor Descriptor => new LV2Sharp.Descriptor (Natives.lilv_instance_get_descriptor (handle));

		// This is inline.
		//LV2Sharp.LV2Handle LV2Handle => new LV2Sharp.LV2Handle (Natives.lilv_instance_get_handle (handle));
	}
}

namespace LV2Sharp
{
	public class LV2Handle
	{
		IntPtr handle;
		
		public LV2Handle (IntPtr handle)
		{
			this.handle = handle;
		}

		public IntPtr Handle => handle;
	}

	public class URIDMap
	{
		IntPtr handle;
		
		public URIDMap (IntPtr handle)
		{
			this.handle = handle;
		}

		public IntPtr Handle => handle;
	}
	
	public class URIDUnmap
	{
		IntPtr handle;
		
		public URIDUnmap (IntPtr handle)
		{
			this.handle = handle;
		}

		public IntPtr Handle => handle;
	}

	
	public class Feature
	{
		IntPtr handle;
		
		public Feature (IntPtr handle)
		{
			this.handle = handle;
		}

		public IntPtr Handle => handle;
	}

	public class Descriptor
	{
		IntPtr handle;
		
		public Descriptor (IntPtr handle)
		{
			this.handle = handle;
		}

		public IntPtr Handle => handle;
	}
}