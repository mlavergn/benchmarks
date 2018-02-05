###############################################
#
# Makefile
#
###############################################

TARGET=main

all: run clean

build:
	go build $(TARGET).go

run: build
	/usr/bin/time -l go run $(TARGET).go

dist: build

clean:
	rm $(TARGET)

ver:
	go version