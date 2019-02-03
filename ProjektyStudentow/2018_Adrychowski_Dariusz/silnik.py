#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Wed Jan  2 23:43:16 2019

@author: adrych
"""

from rpi_step_motor import Steper


class Silnik():

    def __init__(self):
        Steper.Setup()

    def move(x, D):

        move = Steper()
        xx = 0
        yy = 0
        if x > 0:
            xx = 1
        elif x > 0:
            xx = -1

        move.Step(xx, D)
