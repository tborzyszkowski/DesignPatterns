import cv2
from image import Image


class Face:

    def __init__(self, image, x, y, width, height, rgb_color):
        self.image = image
        self.x = x
        self.y = y
        self.width = width
        self.height = height
        self.rgb_color = rgb_color

    def draw(self, thickness):
        cv2.rectangle(self.image, (self.x, self.y), (self.__top_left_corner(), self.__bottom_right_corner()),
                      self.rgb_color, thickness)

    def data(self):
        return self.image[self.y:self.y + self.height, self.x:self.x + self.width]

    def show(self):
        cv2.imshow(str(self.x) + str(self.y) + " face", self.data())
        cv2.waitKey(0)
        cv2.destroyAllWindows()

    def __top_left_corner(self):
        return self.x + self.width

    def __bottom_right_corner(self):
        return self.y + self.height

    def wspol_x(self):
        return (2 * self.x + self.width) / 2

    def wspol_y(self):
        return (2 * self.y + self.height) / 2
