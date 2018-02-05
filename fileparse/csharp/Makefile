###############################################
#
# Makefile
#
###############################################

CC=/usr/local/share/dotnet/dotnet

all: run clean

build:
	$(CC) build

run: build
	$(CC) run

setup:
	$(CC) new console

clean:
	rm -r bin
	rm -r obj

ver:
	$(CC) --version