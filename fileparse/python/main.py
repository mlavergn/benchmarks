#!/usr/bin/python

import timeit

setup = '''
import os

def FileTest(path):
	file = open(path, "r")
	lines = file.readlines()

	data = [None for i in range(len(lines))]
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
elapsed = timeit.timeit("FileTest(os.getcwd() + '/../employees.txt')", setup=setup, number=1)
print(elapsed * 1000.0, "ms - cold")

elapsed = timeit.timeit("FileTest(os.getcwd() + '/../employees.txt')", setup=setup, number=1)
print(elapsed * 1000.0, "ms - warm")
