#!/usr/bin/python

import timeit

setup = '''
import os

def FileTest(path):
	file = open(path, "rw")
	lines = file.readlines()

	data = [None for i in xrange(len(lines))]
	i = 0
	for line in lines:
		data[i] = line.split(',')
		j = 0
		for field in data[i]:
			data[i][j] = field.strip('\\'\\n')
			j += 1
		i += 1
		
	return data	
'''

print timeit.timeit("FileTest(os.getcwd() + '/../employees.txt')", setup=setup, number=1) * 1000.0
