# -*- coding: utf-8 -*-
"""
Created on Fri Dec 21 10:56:03 2018

@author: m198588
"""

import cv2
import time


class CameraClass:
    class __CameraClass:
        def __init__(self):
            self.video_capture = None

        def __str__(self):
            return repr(self)

    instance = None

    def __init__(self):
        if not CameraClass.instance:
            CameraClass.instance = CameraClass.__CameraClass()
        else:
            self.video_capture = None

    def __getattr__(self, name):
        return getattr(self.instance, name)

    def prepare(self, source):
        self.video_capture = cv2.VideoCapture(source)
        time.sleep(5)
        self.video_capture.open(source)
        return self

    def singleFrame(self):
        _, frame = self.video_capture.read()
        return frame

    def endRecording(self):
        self.video_capture.release()
        cv2.destroyAllWindows()
