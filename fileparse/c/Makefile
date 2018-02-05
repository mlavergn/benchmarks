###############################################
#
# Makefile
#
###############################################

# srcdir = .
# prefix = /usr/local
# exec_prefix = ${prefix}

# bindir = $(DESTDIR)${exec_prefix}/bin
# mandir = $(DESTDIR)${prefix}/man
# libdir = $(DESTDIR)${exec_prefix}/lib

# man1dir = $(mandir)/man1

CC     =  clang
LD     =  ld
CFLAGS =  -g -O2
# DEFS   =  -DHAVE_CONFIG_H
# SHELL  =  /bin/sh
# LIBS   = -lsocket

TARGET=main

all: build run clean

build:
	$(CC) $(CFLAGS) $(TARGET).c -o main $(LIBS)

run:
	./main

clean:
	rm -rf core $(TARGET).o a.out $(TARGET).dSYM $(TARGET)

ver:
	clang --version