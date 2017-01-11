###############################################
#
# Makefile
#
###############################################

TARGET=main

all: build

build:
	swiftc $(TARGET).swift

run:
	swift $(TARGET).swift

dist: build

clean:
	rm -f $(TARGET)

ver:
	swift -version