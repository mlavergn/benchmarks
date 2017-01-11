###############################################
#
# Makefile
#
###############################################

TARGET=Main

all: build

build:
	javac -cp . $(TARGET).java

run:
	java -cp . $(TARGET)

dist: build

clean:
	rm -f $(TARGET).class

ver:
	java -version