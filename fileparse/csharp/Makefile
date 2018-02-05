###############################################
#
# Makefile
#
###############################################

# https://www.microsoft.com/net/learn/get-started/macos

CC=/usr/local/share/dotnet/dotnet

all: run clean

build:
	$(CC) build

run: build
	/usr/bin/time -l $(CC) run

setup:
	$(CC) new console

clean:
	rm -r bin
	rm -r obj

ver:
	$(CC) --version