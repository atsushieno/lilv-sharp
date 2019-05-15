
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

namespace LV2Sharp.LV2.AtomNS
{

	[Label ("Atom")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Atom")]
	public class Atom : System.Object
	{
	}


	[Label ("Atom Port")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#AtomPort")]
	public class AtomPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Blank")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Blank")]
	public class Blank : LV2Sharp.LV2.AtomNS.Object
	{
	}


	[Label ("Boolean")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Bool")]
	public class Bool : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Chunk of memory")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Chunk")]
	public class Chunk : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("64-bit floating point number")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Double")]
	public class Double : LV2Sharp.LV2.AtomNS.Number
	{
	}


	[Label ("Event")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Event")]
	public class Event : System.Object
	{
	}


	[Label ("32-bit floating point number")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Float")]
	public class Float : LV2Sharp.LV2.AtomNS.Number
	{
	}


	[Label ("Signed 32-bit integer")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Int")]
	public class Int : LV2Sharp.LV2.AtomNS.Number
	{
	}


	[Label ("String Literal")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Literal")]
	public class Literal : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Signed 64-bit integer")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Long")]
	public class Long : LV2Sharp.LV2.AtomNS.Number
	{
	}


	[Label ("Number")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Number")]
	public class Number : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Object")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Object")]
	public class Object : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("File path string")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Path")]
	public class Path : LV2Sharp.LV2.AtomNS.URI
	{
	}


	[Label ("Property")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Property")]
	public class Property : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Resource")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Resource")]
	public class Resource : LV2Sharp.LV2.AtomNS.Object
	{
	}


	[Label ("Sequence")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Sequence")]
	public class Sequence : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Sound")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Sound")]
	public class Sound : LV2Sharp.LV2.AtomNS.Vector
	{
	}


	[Label ("String")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#String")]
	public class String : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Tuple")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Tuple")]
	public class Tuple : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("URI string")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#URI")]
	public class URI : LV2Sharp.LV2.AtomNS.String
	{
	}


	[Label ("Integer URID")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#URID")]
	public class URID : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Vector")]
	[PluginUri ("http://lv2plug.in/ns/ext/atom#Vector")]
	public class Vector : LV2Sharp.LV2.AtomNS.Atom
	{
	}

}
namespace LV2Sharp.LV2.DynManifest
{

	[Label ("Dynamic Manifest")]
	[PluginUri ("http://lv2plug.in/ns/ext/dynmanifest#DynManifest")]
	public class DynManifest : System.Object
	{
	}

}
namespace LV2Sharp.LV2.EventNS
{

	[Label ("Event")]
	[PluginUri ("http://lv2plug.in/ns/ext/event#Event")]
	public class Event : System.Object
	{
	}


	[Label ("Event Port")]
	[PluginUri ("http://lv2plug.in/ns/ext/event#EventPort")]
	public class EventPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Audio Frame Time Stamp")]
	[PluginUri ("http://lv2plug.in/ns/ext/event#FrameStamp")]
	public class FrameStamp : LV2Sharp.LV2.EventNS.TimeStamp
	{
	}


	[Label ("Event Time Stamp")]
	[PluginUri ("http://lv2plug.in/ns/ext/event#TimeStamp")]
	public class TimeStamp : System.Object
	{
	}

}
namespace LV2Sharp.LV2.Log
{

	[Label ("Log Entry")]
	[PluginUri ("http://lv2plug.in/ns/ext/log#Entry")]
	public class Entry : System.Object
	{
	}


	[Label ("Error")]
	[PluginUri ("http://lv2plug.in/ns/ext/log#Error")]
	public class Error : LV2Sharp.LV2.Log.Entry
	{
	}


	[Label ("Note")]
	[PluginUri ("http://lv2plug.in/ns/ext/log#Note")]
	public class Note : LV2Sharp.LV2.Log.Entry
	{
	}


	[Label ("Trace")]
	[PluginUri ("http://lv2plug.in/ns/ext/log#Trace")]
	public class Trace : LV2Sharp.LV2.Log.Entry
	{
	}


	[Label ("Warning")]
	[PluginUri ("http://lv2plug.in/ns/ext/log#Warning")]
	public class Warning : LV2Sharp.LV2.Log.Entry
	{
	}

}
namespace LV2Sharp.LV2.Midi
{

	[Label ("Active Sense Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#ActiveSense")]
	public class ActiveSense : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("Aftertouch Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Aftertouch")]
	public class Aftertouch : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("Bender Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Bender")]
	public class Bender : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("Channel Pressure Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#ChannelPressure")]
	public class ChannelPressure : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("MIDI Chunk")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Chunk")]
	public class Chunk : System.Object
	{
	}


	[Label ("Clock Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Clock")]
	public class Clock : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("Continue Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Continue")]
	public class Continue : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("Controller Change Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Controller")]
	public class Controller : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("MIDI Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#MidiEvent")]
	public class MidiEvent : LV2Sharp.LV2.AtomNS.Atom
	{
	}


	[Label ("Note Off Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#NoteOff")]
	public class NoteOff : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("Note On Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#NoteOn")]
	public class NoteOn : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("Program Change Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#ProgramChange")]
	public class ProgramChange : LV2Sharp.LV2.Midi.VoiceMessage
	{
	}


	[Label ("Quarter Frame Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#QuarterFrame")]
	public class QuarterFrame : LV2Sharp.LV2.Midi.SystemCommon
	{
	}


	[Label ("Reset Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Reset")]
	public class Reset : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("Song Position Pointer Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SongPosition")]
	public class SongPosition : LV2Sharp.LV2.Midi.SystemCommon
	{
	}


	[Label ("Song Select Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SongSelect")]
	public class SongSelect : LV2Sharp.LV2.Midi.SystemCommon
	{
	}


	[Label ("Start Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Start")]
	public class Start : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("Stop Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#Stop")]
	public class Stop : LV2Sharp.LV2.Midi.SystemRealtime
	{
	}


	[Label ("System Common Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SystemCommon")]
	public class SystemCommon : LV2Sharp.LV2.Midi.SystemMessage
	{
	}


	[Label ("System Exclusive Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SystemExclusive")]
	public class SystemExclusive : LV2Sharp.LV2.Midi.SystemMessage
	{
	}


	[Label ("System Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SystemMessage")]
	public class SystemMessage : LV2Sharp.LV2.Midi.MidiEvent
	{
	}


	[Label ("System Realtime Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#SystemRealtime")]
	public class SystemRealtime : LV2Sharp.LV2.Midi.SystemMessage
	{
	}


	[Label ("Tune Request Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#TuneRequest")]
	public class TuneRequest : LV2Sharp.LV2.Midi.SystemCommon
	{
	}


	[Label ("Voice Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/midi#VoiceMessage")]
	public class VoiceMessage : LV2Sharp.LV2.Midi.MidiEvent
	{
	}

}
namespace LV2Sharp.LV2.Morph
{

	[Label ("Auto Morph Port")]
	[PluginUri ("http://lv2plug.in/ns/ext/morph#AutoMorphPort")]
	public class AutoMorphPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Morph Port")]
	[PluginUri ("http://lv2plug.in/ns/ext/morph#MorphPort")]
	public class MorphPort : LV2Sharp.LV2.Port
	{
	}

}
namespace LV2Sharp.LV2.Options
{

	[Label ("Option")]
	[PluginUri ("http://lv2plug.in/ns/ext/options#Option")]
	public class Option : LV2Sharp.RdfSyntax.Property
	{
	}

}
namespace LV2Sharp.LV2.Parameters
{

	[Label ("Compressor Controls")]
	[PluginUri ("http://lv2plug.in/ns/ext/parameters#CompressorControls")]
	public class CompressorControls : LV2Sharp.LV2.Parameters.ControlGroup
	{
	}


	[Label ("")]
	[PluginUri ("http://lv2plug.in/ns/ext/parameters#ControlGroup")]
	public class ControlGroup : LV2Sharp.LV2.PortGroups.Group
	{
	}


	[Label ("DAHDSR Envelope Controls")]
	[PluginUri ("http://lv2plug.in/ns/ext/parameters#EnvelopeControls")]
	public class EnvelopeControls : LV2Sharp.LV2.Parameters.ControlGroup
	{
	}


	[Label ("Filter Controls")]
	[PluginUri ("http://lv2plug.in/ns/ext/parameters#FilterControls")]
	public class FilterControls : LV2Sharp.LV2.Parameters.ControlGroup
	{
	}


	[Label ("Oscillator Controls")]
	[PluginUri ("http://lv2plug.in/ns/ext/parameters#OscillatorControls")]
	public class OscillatorControls : LV2Sharp.LV2.Parameters.ControlGroup
	{
	}

}
namespace LV2Sharp.LV2.PatchNS
{

	[Label ("Ack")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Ack")]
	public class Ack : LV2Sharp.LV2.PatchNS.Response
	{
	}


	[Label ("Copy")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Copy")]
	public class Copy : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Delete")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Delete")]
	public class Delete : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Error")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Error")]
	public class Error : LV2Sharp.LV2.PatchNS.Response
	{
	}


	[Label ("Get")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Get")]
	public class Get : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Insert")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Insert")]
	public class Insert : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Patch Message")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Message")]
	public class Message : System.Object
	{
	}


	[Label ("Move")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Move")]
	public class Move : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Patch")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Patch")]
	public class Patch : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Put")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Put")]
	public class Put : LV2Sharp.LV2.PatchNS.Request
	{
	}


	[Label ("Request")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Request")]
	public class Request : LV2Sharp.LV2.PatchNS.Message
	{
	}


	[Label ("Response")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Response")]
	public class Response : LV2Sharp.LV2.PatchNS.Message
	{
	}


	[Label ("Set")]
	[PluginUri ("http://lv2plug.in/ns/ext/patch#Set")]
	public class Set : LV2Sharp.LV2.PatchNS.Request
	{
	}

}
namespace LV2Sharp.LV2.PortGroups
{

	[Label ("Ambisonic B stream of horizontal order 1 and peripheral order 0.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH1P0Group")]
	public class AmbisonicBH1P0Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 1 and peripheral order 1.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH1P1Group")]
	public class AmbisonicBH1P1Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 2 and peripheral order 0.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH2P0Group")]
	public class AmbisonicBH2P0Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 2 and peripheral order 1.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH2P1Group")]
	public class AmbisonicBH2P1Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 2 and peripheral order 2.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH2P2Group")]
	public class AmbisonicBH2P2Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 3 and peripheral order 0.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH3P0Group")]
	public class AmbisonicBH3P0Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 3 and peripheral order 1.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH3P1Group")]
	public class AmbisonicBH3P1Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 3 and peripheral order 2.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH3P2Group")]
	public class AmbisonicBH3P2Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("Ambisonic B stream of horizontal order 3 and peripheral order 3.")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicBH3P3Group")]
	public class AmbisonicBH3P3Group : LV2Sharp.LV2.PortGroups.AmbisonicGroup
	{
	}


	[Label ("")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#AmbisonicGroup")]
	public class AmbisonicGroup : LV2Sharp.LV2.PortGroups.Group
	{
	}


	[Label ("")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#DiscreteGroup")]
	public class DiscreteGroup : LV2Sharp.LV2.PortGroups.Group
	{
	}


	[Label ("Element")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#Element")]
	public class Element : System.Object
	{
	}


	[Label ("5.1 Surround (3-2 stereo)")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#FivePointOneGroup")]
	public class FivePointOneGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("5.0 Surround (3-2 stereo)")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#FivePointZeroGroup")]
	public class FivePointZeroGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("4.0 Surround (Quadraphonic)")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#FourPointZeroGroup")]
	public class FourPointZeroGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("Port Group")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#Group")]
	public class Group : System.Object
	{
	}


	[Label ("Input Group")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#InputGroup")]
	public class InputGroup : LV2Sharp.LV2.PortGroups.Group
	{
	}


	[Label ("Mid-Side Stereo")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#MidSideGroup")]
	public class MidSideGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("Mono")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#MonoGroup")]
	public class MonoGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("Output Group")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#OutputGroup")]
	public class OutputGroup : LV2Sharp.LV2.PortGroups.Group
	{
	}


	[Label ("7.1 Surround")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#SevenPointOneGroup")]
	public class SevenPointOneGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("7.1 Surround (Wide)")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#SevenPointOneWideGroup")]
	public class SevenPointOneWideGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("6.1 Surround")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#SixPointOneGroup")]
	public class SixPointOneGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("Stereo")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#StereoGroup")]
	public class StereoGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}


	[Label ("3.0 Surround")]
	[PluginUri ("http://lv2plug.in/ns/ext/port-groups#ThreePointZeroGroup")]
	public class ThreePointZeroGroup : LV2Sharp.LV2.PortGroups.DiscreteGroup
	{
	}

}
namespace LV2Sharp.LV2.Presets
{

	[Label ("Bank")]
	[PluginUri ("http://lv2plug.in/ns/ext/presets#Bank")]
	public class Bank : System.Object
	{
	}


	[Label ("Preset")]
	[PluginUri ("http://lv2plug.in/ns/ext/presets#Preset")]
	public class Preset : LV2Sharp.LV2.PluginBase
	{
	}

}
namespace LV2Sharp.LV2.StateNS
{

	[Label ("State changed")]
	[PluginUri ("http://lv2plug.in/ns/ext/state#Changed")]
	public class Changed : System.Object
	{
	}


	[Label ("State")]
	[PluginUri ("http://lv2plug.in/ns/ext/state#State")]
	public class State : System.Object
	{
	}

}
namespace LV2Sharp.LV2.TimeNS
{

	[Label ("Position")]
	[PluginUri ("http://lv2plug.in/ns/ext/time#Position")]
	public class Position : System.Object
	{
	}


	[Label ("Rate")]
	[PluginUri ("http://lv2plug.in/ns/ext/time#Rate")]
	public class Rate : LV2Sharp.LV2.TimeNS.Position
	{
	}


	[Label ("Time")]
	[PluginUri ("http://lv2plug.in/ns/ext/time#Time")]
	public class Time : LV2Sharp.LV2.TimeNS.Position
	{
	}

}
namespace LV2Sharp.LV2.UINS
{

	[Label ("Cocoa UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#CocoaUI")]
	public class CocoaUI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("GTK3 UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#Gtk3UI")]
	public class Gtk3UI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("GTK2 UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#GtkUI")]
	public class GtkUI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#PortNotification")]
	public class PortNotification : System.Object
	{
	}


	[Label ("Port Protocol")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#PortProtocol")]
	public class PortProtocol : LV2Sharp.LV2.Feature
	{
	}


	[Label ("Qt4 UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#Qt4UI")]
	public class Qt4UI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("Qt5 UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#Qt5UI")]
	public class Qt5UI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("User Interface")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#UI")]
	public class UI : System.Object
	{
	}


	[Label ("Windows UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#WindowsUI")]
	public class WindowsUI : LV2Sharp.LV2.UINS.UI
	{
	}


	[Label ("X11 UI")]
	[PluginUri ("http://lv2plug.in/ns/extensions/ui#X11UI")]
	public class X11UI : LV2Sharp.LV2.UINS.UI
	{
	}

}
namespace LV2Sharp.LV2.Units
{

	[Label ("Conversion")]
	[PluginUri ("http://lv2plug.in/ns/extensions/units#Conversion")]
	public class Conversion : System.Object
	{
	}


	[Label ("Unit")]
	[PluginUri ("http://lv2plug.in/ns/extensions/units#Unit")]
	public class Unit : System.Object
	{
	}

}
namespace LV2Sharp.LV2
{

	[Label ("Allpass")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#AllpassPlugin")]
	public class AllpassPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("Amplifier")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#AmplifierPlugin")]
	public class AmplifierPlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Analyser")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#AnalyserPlugin")]
	public class AnalyserPlugin : LV2Sharp.LV2.UtilityPlugin
	{
	}


	[Label ("Audio Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#AudioPort")]
	public class AudioPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Bandpass")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#BandpassPlugin")]
	public class BandpassPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("CV Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#CVPort")]
	public class CVPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Channel")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Channel")]
	public class Channel : LV2Sharp.LV2.Designation
	{
	}


	[Label ("Chorus")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ChorusPlugin")]
	public class ChorusPlugin : LV2Sharp.LV2.ModulatorPlugin
	{
	}


	[Label ("Comb")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#CombPlugin")]
	public class CombPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("Compressor")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#CompressorPlugin")]
	public class CompressorPlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Constant")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ConstantPlugin")]
	public class ConstantPlugin : LV2Sharp.LV2.GeneratorPlugin
	{
	}


	[Label ("Control Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ControlPort")]
	public class ControlPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Converter")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ConverterPlugin")]
	public class ConverterPlugin : LV2Sharp.LV2.UtilityPlugin
	{
	}


	[Label ("Delay")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#DelayPlugin")]
	public class DelayPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Designation")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Designation")]
	public class Designation : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("Distortion")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#DistortionPlugin")]
	public class DistortionPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Dynamics")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#DynamicsPlugin")]
	public class DynamicsPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Equaliser")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#EQPlugin")]
	public class EQPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("Envelope")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#EnvelopePlugin")]
	public class EnvelopePlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Expander")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ExpanderPlugin")]
	public class ExpanderPlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Extension Data")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ExtensionData")]
	public class ExtensionData : System.Object
	{
	}


	[Label ("Feature")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Feature")]
	public class Feature : System.Object
	{
	}


	[Label ("Filter")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#FilterPlugin")]
	public class FilterPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Flanger")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#FlangerPlugin")]
	public class FlangerPlugin : LV2Sharp.LV2.ModulatorPlugin
	{
	}


	[Label ("Function")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#FunctionPlugin")]
	public class FunctionPlugin : LV2Sharp.LV2.UtilityPlugin
	{
	}


	[Label ("Gate")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#GatePlugin")]
	public class GatePlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Generator")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#GeneratorPlugin")]
	public class GeneratorPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Highpass")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#HighpassPlugin")]
	public class HighpassPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("Input Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#InputPort")]
	public class InputPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Instrument")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#InstrumentPlugin")]
	public class InstrumentPlugin : LV2Sharp.LV2.GeneratorPlugin
	{
	}


	[Label ("Limiter")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#LimiterPlugin")]
	public class LimiterPlugin : LV2Sharp.LV2.DynamicsPlugin
	{
	}


	[Label ("Lowpass")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#LowpassPlugin")]
	public class LowpassPlugin : LV2Sharp.LV2.FilterPlugin
	{
	}


	[Label ("MIDI")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#MIDIPlugin")]
	public class MIDIPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Mixer")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#MixerPlugin")]
	public class MixerPlugin : LV2Sharp.LV2.UtilityPlugin
	{
	}


	[Label ("Modulator")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ModulatorPlugin")]
	public class ModulatorPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Multiband")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#MultiEQPlugin")]
	public class MultiEQPlugin : LV2Sharp.LV2.EQPlugin
	{
	}


	[Label ("Oscillator")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#OscillatorPlugin")]
	public class OscillatorPlugin : LV2Sharp.LV2.GeneratorPlugin
	{
	}


	[Label ("Output Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#OutputPort")]
	public class OutputPort : LV2Sharp.LV2.Port
	{
	}


	[Label ("Parametric")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ParaEQPlugin")]
	public class ParaEQPlugin : LV2Sharp.LV2.EQPlugin
	{
	}


	[Label ("Parameter")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Parameter")]
	public class Parameter : LV2Sharp.LV2.Designation
	{
	}


	[Label ("Phaser")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#PhaserPlugin")]
	public class PhaserPlugin : LV2Sharp.LV2.ModulatorPlugin
	{
	}


	[Label ("Pitch Shifter")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#PitchPlugin")]
	public class PitchPlugin : LV2Sharp.LV2.SpectralPlugin
	{
	}


	[Label ("Plugin")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Plugin")]
	public class Plugin : LV2Sharp.LV2.PluginBase
	{
	}


	[Label ("Plugin Base")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#PluginBase")]
	public class PluginBase : System.Object
	{
	}


	[Label ("Point")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Point")]
	public class Point : System.Object
	{
	}


	[Label ("Port")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Port")]
	public class Port : LV2Sharp.LV2.PortBase
	{
	}


	[Label ("Port Base")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#PortBase")]
	public class PortBase : System.Object
	{
	}


	[Label ("Port Property")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#PortProperty")]
	public class PortProperty : System.Object
	{
	}


	[Label ("Reverb")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ReverbPlugin")]
	public class ReverbPlugin : LV2Sharp.LV2.DelayPlugin
	{
	}


	[Label ("Scale Point")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#ScalePoint")]
	public class ScalePoint : LV2Sharp.LV2.Point
	{
	}


	[Label ("Simulator")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#SimulatorPlugin")]
	public class SimulatorPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Spatial")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#SpatialPlugin")]
	public class SpatialPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#Specification")]
	public class Specification : LV2Sharp.Doap.Project
	{
	}


	[Label ("Spectral")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#SpectralPlugin")]
	public class SpectralPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Utility")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#UtilityPlugin")]
	public class UtilityPlugin : LV2Sharp.LV2.Plugin
	{
	}


	[Label ("Waveshaper")]
	[PluginUri ("http://lv2plug.in/ns/lv2core#WaveshaperPlugin")]
	public class WaveshaperPlugin : LV2Sharp.LV2.DistortionPlugin
	{
	}

}
namespace LV2Sharp.DoapBugs
{

	[Label ("")]
	[PluginUri ("http://ontologi.es/doap-bugs#Issue")]
	public class Issue : System.Object
	{
	}

}
namespace LV2Sharp.Dct
{

	[Label ("Agent")]
	[PluginUri ("http://purl.org/dc/terms/Agent")]
	public class Agent : System.Object
	{
	}


	[Label ("Agent Class")]
	[PluginUri ("http://purl.org/dc/terms/AgentClass")]
	public class AgentClass : System.Object
	{
	}


	[Label ("License Document")]
	[PluginUri ("http://purl.org/dc/terms/LicenseDocument")]
	public class LicenseDocument : LV2Sharp.Dct.RightsStatement
	{
	}


	[Label ("Linguistic System")]
	[PluginUri ("http://purl.org/dc/terms/LinguisticSystem")]
	public class LinguisticSystem : System.Object
	{
	}


	[Label ("Media Type")]
	[PluginUri ("http://purl.org/dc/terms/MediaType")]
	public class MediaType : LV2Sharp.Dct.MediaTypeOrExtent
	{
	}


	[Label ("Media Type or Extent")]
	[PluginUri ("http://purl.org/dc/terms/MediaTypeOrExtent")]
	public class MediaTypeOrExtent : System.Object
	{
	}


	[Label ("Rights Statement")]
	[PluginUri ("http://purl.org/dc/terms/RightsStatement")]
	public class RightsStatement : System.Object
	{
	}


	[Label ("Standard")]
	[PluginUri ("http://purl.org/dc/terms/Standard")]
	public class Standard : System.Object
	{
	}

}
namespace LV2Sharp.Doap
{

	[Label ("Dépôt GNU Arch")]
	[PluginUri ("http://usefulinc.com/ns/doap#ArchRepository")]
	public class ArchRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("BitKeeper Repository")]
	[PluginUri ("http://usefulinc.com/ns/doap#BKRepository")]
	public class BKRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Bazaar Branch")]
	[PluginUri ("http://usefulinc.com/ns/doap#BazaarBranch")]
	public class BazaarBranch : LV2Sharp.Doap.Repository
	{
	}


	[Label ("CVS Repository")]
	[PluginUri ("http://usefulinc.com/ns/doap#CVSRepository")]
	public class CVSRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Dépôt darcs")]
	[PluginUri ("http://usefulinc.com/ns/doap#DarcsRepository")]
	public class DarcsRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Git Branch")]
	[PluginUri ("http://usefulinc.com/ns/doap#GitBranch")]
	public class GitBranch : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Mercurial Repository")]
	[PluginUri ("http://usefulinc.com/ns/doap#HgRepository")]
	public class HgRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Prijekt")]
	[PluginUri ("http://usefulinc.com/ns/doap#Project")]
	public class Project : LV2Sharp.Foaf.Project
	{
	}


	[Label ("Dépôt")]
	[PluginUri ("http://usefulinc.com/ns/doap#Repository")]
	public class Repository : System.Object
	{
	}


	[Label ("Dépôt Subversion")]
	[PluginUri ("http://usefulinc.com/ns/doap#SVNRepository")]
	public class SVNRepository : LV2Sharp.Doap.Repository
	{
	}


	[Label ("Specification")]
	[PluginUri ("http://usefulinc.com/ns/doap#Specification")]
	public class Specification : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Version")]
	[PluginUri ("http://usefulinc.com/ns/doap#Version")]
	public class Version : System.Object
	{
	}

}
namespace LV2Sharp.RdfSyntax
{

	[Label ("Alt")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#Alt")]
	public class Alt : LV2Sharp.RdfSchema.Container
	{
	}


	[Label ("Bag")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#Bag")]
	public class Bag : LV2Sharp.RdfSchema.Container
	{
	}


	[Label ("List")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#List")]
	public class List : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Property")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#Property")]
	public class Property : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Seq")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#Seq")]
	public class Seq : LV2Sharp.RdfSchema.Container
	{
	}


	[Label ("Statement")]
	[PluginUri ("http://www.w3.org/1999/02/22-rdf-syntax-ns#Statement")]
	public class Statement : LV2Sharp.RdfSchema.Resource
	{
	}

}
namespace LV2Sharp.RdfSchema
{

	[Label ("Class")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#Class")]
	public class Class : System.Object
	{
	}


	[Label ("Container")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#Container")]
	public class Container : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Container Membership Property")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#ContainerMembershipProperty")]
	public class ContainerMembershipProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("Datatype")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#Datatype")]
	public class Datatype : LV2Sharp.RdfSchema.Class
	{
	}


	[Label ("Literal")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#Literal")]
	public class Literal : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Resource")]
	[PluginUri ("http://www.w3.org/2000/01/rdf-schema#Resource")]
	public class Resource : System.Object
	{
	}

}
namespace LV2Sharp.Owl
{

	[Label ("AllDifferent")]
	[PluginUri ("http://www.w3.org/2002/07/owl#AllDifferent")]
	public class AllDifferent : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("AllDisjointClasses")]
	[PluginUri ("http://www.w3.org/2002/07/owl#AllDisjointClasses")]
	public class AllDisjointClasses : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("AllDisjointProperties")]
	[PluginUri ("http://www.w3.org/2002/07/owl#AllDisjointProperties")]
	public class AllDisjointProperties : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Annotation")]
	[PluginUri ("http://www.w3.org/2002/07/owl#Annotation")]
	public class Annotation : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("AnnotationProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#AnnotationProperty")]
	public class AnnotationProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("AsymmetricProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#AsymmetricProperty")]
	public class AsymmetricProperty : LV2Sharp.Owl.ObjectProperty
	{
	}


	[Label ("Axiom")]
	[PluginUri ("http://www.w3.org/2002/07/owl#Axiom")]
	public class Axiom : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("Class")]
	[PluginUri ("http://www.w3.org/2002/07/owl#Class")]
	public class Class : LV2Sharp.RdfSchema.Class
	{
	}


	[Label ("DatatypeProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#DatatypeProperty")]
	public class DatatypeProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("DeprecatedClass")]
	[PluginUri ("http://www.w3.org/2002/07/owl#DeprecatedClass")]
	public class DeprecatedClass : LV2Sharp.RdfSchema.Class
	{
	}


	[Label ("DeprecatedProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#DeprecatedProperty")]
	public class DeprecatedProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("FunctionalProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#FunctionalProperty")]
	public class FunctionalProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("InverseFunctionalProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#InverseFunctionalProperty")]
	public class InverseFunctionalProperty : LV2Sharp.Owl.ObjectProperty
	{
	}


	[Label ("IrreflexiveProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#IrreflexiveProperty")]
	public class IrreflexiveProperty : LV2Sharp.Owl.ObjectProperty
	{
	}


	[Label ("NamedIndividual")]
	[PluginUri ("http://www.w3.org/2002/07/owl#NamedIndividual")]
	public class NamedIndividual : System.Object
	{
	}


	[Label ("NegativePropertyAssertion")]
	[PluginUri ("http://www.w3.org/2002/07/owl#NegativePropertyAssertion")]
	public class NegativePropertyAssertion : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("ObjectProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#ObjectProperty")]
	public class ObjectProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("Ontology")]
	[PluginUri ("http://www.w3.org/2002/07/owl#Ontology")]
	public class Ontology : LV2Sharp.RdfSchema.Resource
	{
	}


	[Label ("OntologyProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#OntologyProperty")]
	public class OntologyProperty : LV2Sharp.RdfSyntax.Property
	{
	}


	[Label ("ReflexiveProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#ReflexiveProperty")]
	public class ReflexiveProperty : LV2Sharp.Owl.ObjectProperty
	{
	}


	[Label ("Restriction")]
	[PluginUri ("http://www.w3.org/2002/07/owl#Restriction")]
	public class Restriction : LV2Sharp.Owl.Class
	{
	}


	[Label ("SymmetricProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#SymmetricProperty")]
	public class SymmetricProperty : LV2Sharp.Owl.ObjectProperty
	{
	}


	[Label ("TransitiveProperty")]
	[PluginUri ("http://www.w3.org/2002/07/owl#TransitiveProperty")]
	public class TransitiveProperty : LV2Sharp.Owl.ObjectProperty
	{
	}

}
namespace LV2Sharp.Foaf
{

	[Label ("Agent")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Agent")]
	public class Agent : System.Object
	{
	}


	[Label ("Document")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Document")]
	public class Document : System.Object
	{
	}


	[Label ("Group")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Group")]
	public class Group : LV2Sharp.Foaf.Agent
	{
	}


	[Label ("Image")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Image")]
	public class Image : LV2Sharp.Foaf.Document
	{
	}


	[Label ("Label Property")]
	[PluginUri ("http://xmlns.com/foaf/0.1/LabelProperty")]
	public class LabelProperty : System.Object
	{
	}


	[Label ("Online Account")]
	[PluginUri ("http://xmlns.com/foaf/0.1/OnlineAccount")]
	public class OnlineAccount : System.Object
	{
	}


	[Label ("Online Chat Account")]
	[PluginUri ("http://xmlns.com/foaf/0.1/OnlineChatAccount")]
	public class OnlineChatAccount : LV2Sharp.Foaf.OnlineAccount
	{
	}


	[Label ("Online E-commerce Account")]
	[PluginUri ("http://xmlns.com/foaf/0.1/OnlineEcommerceAccount")]
	public class OnlineEcommerceAccount : LV2Sharp.Foaf.OnlineAccount
	{
	}


	[Label ("Online Gaming Account")]
	[PluginUri ("http://xmlns.com/foaf/0.1/OnlineGamingAccount")]
	public class OnlineGamingAccount : LV2Sharp.Foaf.OnlineAccount
	{
	}


	[Label ("Organization")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Organization")]
	public class Organization : LV2Sharp.Foaf.Agent
	{
	}


	[Label ("Person")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Person")]
	public class Person : LV2Sharp.Foaf.Agent
	{
	}


	[Label ("PersonalProfileDocument")]
	[PluginUri ("http://xmlns.com/foaf/0.1/PersonalProfileDocument")]
	public class PersonalProfileDocument : LV2Sharp.Foaf.Document
	{
	}


	[Label ("Project")]
	[PluginUri ("http://xmlns.com/foaf/0.1/Project")]
	public class Project : System.Object
	{
	}

}
