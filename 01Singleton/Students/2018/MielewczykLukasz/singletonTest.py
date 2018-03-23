from multiprocessing.pool import ThreadPool
from singleton import Singleton
from singleton import SubSingleton

import pickle
import unittest

	
class SingletonTest(unittest.TestCase):

    def testSingleton(self):
		s1 = Singleton()
		s2 = Singleton()
		self.assertEquals(id(s1), id(s2))
		self.assertTrue(s1 is s2)
		
    def testThread(self):
		def createSingleton():
			s = Singleton()
			return s
		
		t1 = ThreadPool(processes=1)
		t2 = ThreadPool(processes=1)

		self.assertTrue(t1.apply_async(createSingleton).get() is t2.apply_async(createSingleton).get())
		
    def testInherited(self):
		s=Singleton()
		ss1=SubSingleton()
		ss2=SubSingleton()
		self.assertEquals(id(ss1), id(ss2))
		self.assertEquals(id(ss1), id(s))
		self.assertTrue(ss1 is ss2)
		self.assertTrue(ss1 is s)

    def testThreadSerialization(self):
		def deserializable():
			with open(fileName, 'rb') as f:
				return pickle.load(f)
		
		fileName = 'data.pickle'
		
		s1 = Singleton()

		with open(fileName, 'wb') as f:
			pickle.dump(s1, f, pickle.HIGHEST_PROTOCOL)

		t1 = ThreadPool(processes=1)
		t2 = ThreadPool(processes=1)

		self.assertTrue(t1.apply_async(deserializable).get() is t2.apply_async(deserializable).get())
		
if __name__ == '__main__':
    unittest.main()