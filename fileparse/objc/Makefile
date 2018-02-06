###############################################
#
# Makefile
#
###############################################

CC     =  clang
LD     =  ld
CFLAGS =  -x objective-c -F/Applications/Xcode.app/Contents/Developer/Platforms/MacOSX.platform/Developer/SDKs/MacOSX.sdk/System/Library/Frameworks
LIBS   = -framework Foundation -framework Cocoa

TARGET=main

all: build run clean

build:
	$(CC) $(CFLAGS) $(TARGET).m -o main $(LIBS)

run:
	/usr/bin/time -l ./main

clean:
	rm -rf core $(TARGET).o a.out $(TARGET).dSYM $(TARGET)

ver:
	clang --version