# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""

from multiprocessing.pool import ThreadPool
from singleton import Singleton
from singleton import SubSingleton1
from singleton import SubSingleton2

import pickle
import unittest
import time

  
class SingletonTest(unittest.TestCase):

  def test_singleton(self):
    first_singleton = Singleton()
    second_singleton = Singleton()
    self.assertTrue(first_singleton is second_singleton)
        
  def test_inheritance(self):
    main_singleton1=Singleton()
    main_singleton2=Singleton()
    next_singleton1=SubSingleton1()
    next_singleton2=SubSingleton1()
    last_singleton1=SubSingleton2()
    last_singleton2=SubSingleton2()
    self.assertTrue(main_singleton1 is not next_singleton1)
    self.assertTrue(main_singleton1 is not last_singleton1)
    self.assertTrue(next_singleton1 is not last_singleton1)
    self.assertTrue(main_singleton1 is main_singleton2)
    self.assertTrue(next_singleton1 is next_singleton2)
    self.assertTrue(last_singleton1 is last_singleton2)
     
  def test_thread_safety(self):
    def create_singleton(self):
      print("\nbefore creating singleton")
      new_singleton = Singleton()
      time.sleep(1)
      print("\nafter creating singleton")
      
      return new_singleton
    
    pool = ThreadPool(2)
    instances = pool.map(create_singleton, range(2))

    self.assertTrue(instances[0] is instances[1])

  def test_serialization(self):
    def deserializable(self):
      with open("object", 'rb') as file:
        return pickle.load(file)
    
    singleton = Singleton()
    
    with open("object", 'wb') as file:
      pickle.dump(singleton, file, pickle.DEFAULT_PROTOCOL)

    singleton.variable = 2
    
    pool = ThreadPool(2)
    instances = pool.map(deserializable, range(2))

    self.assertTrue(instances[0] is instances[1])
    self.assertTrue(instances[0].variable == None)
    self.assertTrue(instances[1].variable == None)

if __name__ == '__main__':
    unittest.main()