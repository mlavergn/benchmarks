###############################################
#
# Makefile
#
###############################################

TARGET=main

all: build

build:
	swiftc -O $(TARGET).swift

run:
	swift -O $(TARGET).swift

dist: build

clean:
	rm -f $(TARGET)

ver:
	swift -version