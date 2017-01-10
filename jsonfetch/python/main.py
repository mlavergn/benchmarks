#!/usr/bin/python

import timeit

setup = '''
import urllib2
import json

def JSONTest(url):
	request = urllib2.Request(url)
	request.add_header("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2 like Mac OS X) AppleWebKit/602.3.12 (KHTML, like Gecko) Version/10.0 Mobile/14C92 Safari/602.1")
	sock = urllib2.urlopen(request, data=None)
	
	jsonMap = json.load(sock)
	sock.close()
	
	return jsonMap["ip"]
'''

print timeit.timeit("JSONTest('http://iotjson.appspot.com')", setup=setup, number=1) * 1000.0
