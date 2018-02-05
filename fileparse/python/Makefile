###############################################
#
# Makefile
#
###############################################

TARGET=main

all: run

build:

run:
	/usr/bin/time -l python3 $(TARGET).py

dist: build

clean:
	rm -f $(TARGET)

ver:
	python3 --version