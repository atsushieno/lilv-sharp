
NCLANG=../../nclang

LV2_HEADERS = `find  /usr/lib/lv2/ -name *.h`


all: lib

lib: generated-sources
	# csc -debug -out:lv2-sharp.dll lv2-interop.cs -t:library -unsafe
	csc -debug -out:lilv-sharp.dll LilvSharp.cs lilv-interop.cs -t:library -unsafe
	csc -debug -r:lilv-sharp.dll -out:lilv-sharp-sample.exe ../lilv-sharp-sample/Program.cs


generated-sources:
	# mono --debug $(NCLANG)/samples/PInvokeGenerator/bin/Debug/net462/PInvokeGenerator.exe --lib:lilv-0 --ns:Lv2Sharp $(LV2_HEADERS) --match:lv2 --arg:"-Duint32_t=unsigned int"  > lv2-interop.cs
	mono --debug $(NCLANG)/samples/PInvokeGenerator/bin/Debug/net462/PInvokeGenerator.exe --lib:lilv-0 --ns:LilvSharp /usr/include/lilv-0/lilv/lilv.h --match:lv2 --match:lilv --arg:"-Duint32_t=unsigned int" --arg:"-DLV2_URID=unsigned int" > lilv-interop.cs
