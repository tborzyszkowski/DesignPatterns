#!/usr/bin/env python
# -*- coding: utf-8 -*-


class Singleton:
	instance = None
    
	def __init__(self):
		if Singleton.instance != None:
			raise Exception("singleton juz istnieje")
		else:
			Singleton.instance = self
            
	@staticmethod
	def getInstance():
		if Singleton.instance == None:
			Singleton()
		return Singleton.instance 

s = Singleton()
print (s)

s = Singleton.getInstance()
print (s)

s = Singleton.getInstance()
print (s) 

#s = Singleton()
#print (s) 
