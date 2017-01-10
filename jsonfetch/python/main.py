#!/usr/bin/python

import timeit

setup = '''
import urllib2
import json

def JSONTest(url):
	request = urllib2.Request(url)
	request.add_header("Content-Type", "application/json")
	sock = urllib2.urlopen(request, data=None)
	
	jsonMap = json.load(sock)
	sock.close()
	
	return jsonMap["ip"]
'''

print timeit.timeit("JSONTest('http://iotjson.appspot.com')", setup=setup, number=1) * 1000.0
