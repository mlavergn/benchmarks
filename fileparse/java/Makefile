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
	# this actually runs slower, here for posterity
	# java -Xmx512M -Xms512M -XX:+AggressiveOpts -XX:CompileThreshold=1 $(TARGET)
	/usr/bin/time -l java -Xmx512M -Xms512M $(TARGET)

dist: build

clean:
	rm -f $(TARGET).class

ver:
	java -version