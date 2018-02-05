###############################################
#
# Makefile
#
###############################################

TARGET=main

all: run

build:
	swiftc -O $(TARGET).swift

run:
	/usr/bin/time -l swift -O $(TARGET).swift

dist: build

clean:
	rm $(TARGET)

ver:
	swift -version