
NCLANG=../nclang


all: lib

lib: generated-sources
	csc -debug -out:lilv-sharp.dll LilvSharp.cs lilv-interop.cs -t:library -unsafe
	csc -debug -r:lilv-sharp.dll -out:lilv-sharp-sample.exe sample.cs


generated-sources:
	mono --debug $(NCLANG)/samples/PInvokeGenerator/bin/Debug/net462/PInvokeGenerator.exe --lib:lilv-0 --ns:LilvSharp /usr/include/lilv-0/lilv/lilv.h --match:lv2 --match:lilv --arg:"-Duint32_t=unsigned int" --arg:"-DLV2_URID=unsigned int" > lilv-interop.cs
