
ROOT=/sources
LV2_PATH=$(ROOT)/LV2/dist/lib/lv2
LD_LIBRARY_PATH=$(ROOT)/LV2/dist/lib:/usr/lib
NCLANG=$(ROOT)/nclang

LV2_HEADERS = `find  /usr/lib/lv2/ -name *.h`


all: lib
	csc -debug -out:lilv-sharp.dll StronglyTypedLV2.cs LilvSharp.cs lilv-interop.cs -t:library -unsafe

lib: tool
	LD_LIBRARY_PATH=$(LD_LIBRARY_PATH) \
	LV2_PATH=$(LV2_PATH) \
	/usr/bin/mono --debug lilv-sharp-sample.exe generate > StronglyTypedLV2.cs

tool: lib-bootstrap
	csc -unsafe -debug -r:lilv-sharp.dll -out:lilv-sharp-sample.exe ../lilv-sharp-sample/Program.cs

lib-bootstrap: generated-sources
	csc -debug -out:lv2-sharp.dll lv2-interop.cs -t:library -unsafe
	csc -debug -out:lilv-sharp.dll LilvSharp.cs lilv-interop.cs -t:library -unsafe


generated-sources:
	mono --debug $(NCLANG)/samples/PInvokeGenerator/bin/Debug/net462/PInvokeGenerator.exe --lib:lv2 --ns:Lv2Sharp.NativeInterop lv2_all.h --match:lv2 \
		--arg:"-Dsize_t=void*" \
		--arg:"-Dintptr_t=int*" \
		--arg:"-Dint64_t=long" \
		--arg:"-Dint32_t=int" \
		--arg:"-Duint64_t=unsigned long" \
		--arg:"-Duint32_t=unsigned int" \
		--arg:"-Duint16_t=unsigned short" \
		--arg:"-DLV2_URID=unsigned int" \
		 > lv2-interop.cs
	mono --debug $(NCLANG)/samples/PInvokeGenerator/bin/Debug/net462/PInvokeGenerator.exe --lib:lilv-0 --ns:LilvSharp.NativeInterop /usr/include/lilv-0/lilv/lilv.h --match:lv2 --match:lilv --arg:"-Duint32_t=unsigned int" --arg:"-DLV2_URID=unsigned int" > lilv-interop.cs
