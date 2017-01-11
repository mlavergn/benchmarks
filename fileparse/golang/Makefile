###############################################
#
# Makefile
#
###############################################

TARGET=main

all: build

build:
	go build $(TARGET).go

run:
	go run $(TARGET).go

dist: build

clean:
	rm -f $(TARGET)

ver:
	go version