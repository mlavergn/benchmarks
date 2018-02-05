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
	go run $(TARGET).go

dist: build

clean:
	rm $(TARGET)

ver:
	go version