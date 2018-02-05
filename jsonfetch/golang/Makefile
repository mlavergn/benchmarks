###############################################
#
# Makefile
#
###############################################

TARGET=main

all: run clean

build:
	go build $(TARGET).go

run:
	go run $(TARGET).go

dist: build

clean:
	rm -f $(TARGET)

ver:
	go version