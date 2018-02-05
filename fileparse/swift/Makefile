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
	swift -O $(TARGET).swift

dist: build

clean:
	rm $(TARGET)

ver:
	swift -version