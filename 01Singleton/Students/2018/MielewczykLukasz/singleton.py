import threading

class Singleton(object):
	threadingLock = threading.Lock()
	instance = None
	
	def __new__(self):
		if not self.instance:
			with Singleton.threadingLock:
				if not self.instance:
					self.instance = object.__new__(self)
		return self.instance

class SubSingleton(Singleton):
	def __new__(self):
		return super(SubSingleton, self).__new__(self)