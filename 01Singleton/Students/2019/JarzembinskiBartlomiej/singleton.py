# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:41:33 2019

@author: Bartlomiej Jarzembinski
"""

from threading import Lock

class Singleton:
  _instances = {}
  _threading_lock = Lock()
  variable = None
  
  def __new__(cls):
    if type(object.__new__(cls)).__name__ not in cls._instances:
      with cls._threading_lock:
        if type(object.__new__(cls)).__name__ not in cls._instances:
          cls._instances[type(object.__new__(cls)).__name__] = object.__new__(cls)
    else:
        cls._instances[type(object.__new__(cls)).__name__].variable = object.__new__(cls).variable
    return cls._instances[type(object.__new__(cls)).__name__]

class SubSingleton1(Singleton):
  pass

class SubSingleton2(SubSingleton1):
  pass