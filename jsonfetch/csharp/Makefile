###############################################
#
# Makefile
#
###############################################

CFLAGS  := /reference:/Applications/Xamarin\ Studio.app/Contents/Resources/lib/monodevelop/bin/Newtonsoft.Json.dll
LDFLAGS :=

AS="as -arch i386"
CC="clang -arch i386 -mmacosx-version-min=10.6 -framework CoreFoundation -lobjc -liconv"
PATH=/Library/Frameworks/Mono.framework/Commands:/usr/bin:$PATH

TARGET=main

all: build

build:
	mcs $(CFLAGS) $(TARGET).cs

run:
	mono $(TARGET).exe

dist:
	mkbundle $(TARGET).exe --deps -o $(TARGET)

clean:
	rm -rf $(TARGET).dSYM $(TARGET).exe $(TARGET)
