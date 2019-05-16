# What is this?

It is an experimental Mono binding for [Lilv](http://drobilla.net/software/lilv).

If you write audio plugins in .NET, you are most likely stupid nowadays.
.NET is not for realtime audio processing.
It might be still useful to write some host programs that carefully handle
memory allocation. Or when you write some authoring helper tools for LV2.
Or static non-realtime audio file processing.

There is a working sample to look up LV2 plugin classes and plugins,
as well as synthesis example in memory (lilv-sharp-sample.exe).

## issues

There is a handful of plugin classes lookup issues in lilv itself so that
it will not list some of the plugin classes such as "Atom" or "UI".
See lilv github issues for details.

## hacking

I don't use MSBuild. I can't, due to broken .NET (Core) releases on Linux
which neither of MSBuild and dotnet team really cares.
They don't fix those bunch of reported Linux packaging issues.

Either way, there is `Makefile` which takes almost all care.

`lilv-interop.cs` is an automatically generated code from [nclang](https://github.com/atsushieno/nclang) PInvokeGenerator. To regenerate it you need nclang.

I have bound almost all functions in lilv.h (manually implemented for
those inline functions too) in `LilvSharp.cs`.

`StronglyTypedLV2.cs` is not in real use. It is a dogfooding outcome from
`lilv-sharp-sample.exe generate` command.

