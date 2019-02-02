from face import Face
import cv2


class Eye(Face):

    def __init__(self, image, x, y, width, height, rgb_color):
        Face.__init__(self, image, x, y, width, height, rgb_color)
