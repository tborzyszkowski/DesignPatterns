# -*- coding: utf-8 -*-
"""
Created on Sat Jan 11 21:56:03 2019

@author: m198588
"""

import time
import camera as cam
import cv2


class CameraManager:
    def available(self):
        print("Camera ready to start!")


class Proxy:
    def __init__(self):
        self.busy = 'No'
        self.available = None
        self.access = None

    def availablility(self):
        print("Proxy checking for Camera availability")
        for source in range(0, 2):
            print("Checking camera {}".format(source))
            if self.availability_test(source):
                self.presentCamera = source
                self.cam1 = cam.CameraClass()
                self.access = 1
                time.sleep(0.1)
            else:
                time.sleep(0.1)
                print("Camera {} is busy/ not present".format(source))
        return self

    def availability_test(self, source):
        cap = cv2.VideoCapture(source)
        if cap is None or not cap.isOpened():
            print("Warning: unable to open video source: {}".format(source))
            self.available = None
        else:
            print("camera {} ready to work".format(source))
            self.available = 1
        return self.available
