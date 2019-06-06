# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""


from factories.burrito_factory import BurritoFactory
from factories.enchilada_factory import EnchiladaFactory
from factories.quesadilla_factory import QuesadillaFactory
from mexican_restaurant_facade import MexicanRestaurant
from multiprocessing.pool import ThreadPool

import pickle
import unittest
import time

  
class SingletonTest(unittest.TestCase):
  discount = 0

  def test_singleton(self):
    first_singleton = BurritoFactory(self.discount)
    second_singleton = BurritoFactory(self.discount)
    self.assertTrue(first_singleton is second_singleton)
        
  def test_inheritance(self):
    first_singleton1 = BurritoFactory(self.discount)
    first_singleton2 = BurritoFactory(self.discount)
    second_singleton1 = EnchiladaFactory(self.discount)
    second_singleton2 = EnchiladaFactory(self.discount)
    third_singleton1 = QuesadillaFactory(self.discount)
    third_singleton2 = QuesadillaFactory(self.discount)
    self.assertTrue(first_singleton1 is first_singleton2)
    self.assertTrue(second_singleton1 is second_singleton2)
    self.assertTrue(third_singleton1 is third_singleton2)
    self.assertTrue(first_singleton1 is not second_singleton1)
    self.assertTrue(first_singleton1 is not third_singleton1)
    self.assertTrue(second_singleton1 is not third_singleton1)
     
  def test_thread_safety(self):
    def create_singleton(self):
      print("\nbefore creating singleton")
      new_singleton = BurritoFactory(0)
      time.sleep(1)
      print("\nafter creating singleton")
      
      return new_singleton
    
    pool = ThreadPool(2)
    instances = pool.map(create_singleton, range(2))

    self.assertTrue(instances[0] is instances[1])

  def test_serialization(self):
    def deserializable(self):
      with open("object", "rb") as file:
        return pickle.load(file)
    
    singleton = MexicanRestaurant()
    
    with open("object", "wb") as file:
      pickle.dump(singleton, file, pickle.DEFAULT_PROTOCOL)
    
    pool = ThreadPool(2)
    instances = pool.map(deserializable, range(2))

    self.assertTrue(instances[0] is instances[1])


if __name__ == "__main__":
    unittest.main()
