#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Wed Jan  2 23:43:16 2019

@author: adrych
"""

# import threading
from obserwator import Observer  # ConcreteObserver
from silnik import Silnik


class SilnikXObserver(Observer):

    def update(self, arg):
        self._observer_state = arg
        print('{} got message "{}"'.format(self._subject.name, arg))
        Silnik.move(arg, "GD")


class SilnikYObserver(Observer):

    def update(self, arg):
        self._observer_state = arg
        print('{} got message "{}"'.format(self._subject.name, arg))
        Silnik.move(arg, "UD")
