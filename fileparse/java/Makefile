###############################################
#
# Makefile
#
###############################################

TARGET=main

all: run clean

build:
	javac $(TARGET).java

run: build
	java $(TARGET)

dist: build

clean:
	rm -f $(TARGET).class

ver:
	java -version