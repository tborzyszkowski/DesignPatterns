#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Thu Jan  3 00:09:17 2019

@author: adrych
"""

# import RPi.GPIO as GPIO
import time


class Steper():
    def __init__(self):
        self.STEPPER_R_PINS = [22, 27, 17, 4]
        self.STEPPER_L_PINS = [18, 23, 25, 24]

        self.STEPPER_SEQ = [[1, 0, 0, 1],
                            [1, 0, 0, 0],
                            [1, 1, 0, 0],
                            [0, 1, 0, 0],
                            [0, 1, 1, 0],
                            [0, 0, 1, 0],
                            [0, 0, 1, 1],
                            [0, 0, 0, 1]]

    def SetupMotor(self, pins):
        for pin in pins:
            # GPIO.setup(pin, GPIO.OUT) # testy bez RPi
            print("setup {} pins as out".format(pin))

    def Setup(self):
        # GPIO.setwarnings(False)
        # GPIO.setmode(GPIO.BCM)
        SetupMotor(self.STEPPER_R_PINS)
        SetupMotor(self.STEPPER_L_PINS)

    def Step(self, step, pins):
        print("Motor {} on move".format(pins))
        if pins == "UD":
            pins = self.STEPPER_R_PINS
        else:
            pins = self.STEPPER_L_PINS
        for c in range(0, 4):
            # GPIO.output(pins[c], STEPPER_SEQ[step][c])
            pass
    # print("Motor move: seq: {} for motor {}".format(step, pins[c]))


"""
Setup() 

for count in range (0, 1000): 
	Step(count % 8, STEPPER_R_PINS) 
	Step(count % 8, STEPPER_L_PINS) 
	time.sleep(0.001)
"""
