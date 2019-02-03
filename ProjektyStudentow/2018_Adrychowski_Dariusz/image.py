import cv2


class Image:
    def __init__(self, image_path, color_type):
        self.image_path = image_path
        self.color_type = color_type
        self.height, self.width = 0, 0

    def load(self):
        image = cv2.imread(self.image_path, self.color_type)
        self.height, self.width = image.shape[:2]
        return image

    def show(self):
        cv2.imshow('Show Image', self.load())
        cv2.waitKey(0)
        cv2.destroyAllWindows()

    @staticmethod
    def show(image):
        cv2.imshow('Show Image', image)
        cv2.waitKey(0)
        cv2.destroyAllWindows()
