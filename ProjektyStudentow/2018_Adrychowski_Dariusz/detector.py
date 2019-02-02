import cv2
from face import Face
from eye import Eye
from classifier import Classifier
import numpy as np
from dekoratory import exception, logged
import obserwator


class Detector:

    def __init__(self, image, scale_factor, minimum_neighbors, minimum_size, flags, classifier):
        self.face_cascade = classifier.face_cascade
        self.eye_cascade = classifier.eye_cascade
        self.smile_cascade = classifier.smile_cascade
        self.image = image
        self.grayscale_image = self.__convert_image_to_gray(image)
        self.scale_factor = scale_factor
        self.minimum_neighbors = minimum_neighbors
        self.minimum_size = minimum_size
        self.flags = flags

    # @logged()
    def detect(self):
        faces = []
        eyes = []
        rgb_green = (0, 255, 0)
        rgb_blue = (0, 0, 255)

        detected_faces = self.__detect_faces()

        for (x, y, w, h) in detected_faces:
            face = Face(self.image, x, y, w, h, rgb_green)
            face.draw(2)
            faces.append(face)
            detected_eyes = self.__detect_eyes(face.data())
            if len(detected_eyes) > 0:
                for (eye_x, eye_y, eye_w, eye_h) in detected_eyes:
                    eye = Eye(self.image, face.x + eye_x, face.y + eye_y, eye_w, eye_h, rgb_blue)
                    eye.draw(2)
                    eyes.append(eye)
            detected_smile = self.__detect_smile(face.data())
            if len(detected_smile) > 0:
                smileness = detected_smile[0][1]
                smile_text_position = ((x - 15), y + (h + 25))
                if smileness >= 15:
                    cv2.putText(self.image, "Smiling: Yes", smile_text_position, cv2.FONT_HERSHEY_DUPLEX, 1,
                                (255, 255, 255))
                else:
                    cv2.putText(self.image, "Smiling: No", smile_text_position, cv2.FONT_HERSHEY_DUPLEX, 1,
                                (255, 255, 255))
            return {"faces": faces, "eyes": eyes}

    # Private Methods
    def __convert_image_to_gray(self, image):
        return cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

    def __detect_faces(self):
        faces = self.face_cascade.detectMultiScale(
            self.grayscale_image,
            scaleFactor=self.scale_factor,
            minNeighbors=self.minimum_neighbors,
            minSize=self.minimum_size,
            flags=self.flags
        )
        return faces

    def __detect_eyes(self, image):
        eyes = self.eye_cascade.detectMultiScale(
            self.__convert_image_to_gray(image)
        )
        return eyes

    def __detect_smile(self, image):
        smiles = self.face_cascade.detectMultiScale(
            self.__convert_image_to_gray(image),
            scaleFactor=self.scale_factor,
            minNeighbors=self.minimum_neighbors,
            minSize=self.minimum_size,
            flags=self.flags
        )
        return smiles
