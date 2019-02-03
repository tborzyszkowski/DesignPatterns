import cv2

xml_path = "haarcascades/xml/"

cascade_path = {
    "alt": xml_path + "haarcascade_frontalface_alt.xml",
    "alt2": xml_path + "haarcascade_frontalface_alt2.xml",
    "alt3": xml_path + "haarcascade_frontalface_alt_tree.xml",
    "default": xml_path + "haarcascade_frontalface_default.xml",
    "eye": xml_path + "haarcascade_eye.xml",
    "eye_glasses": xml_path + "haarcascade_eye_tree_eyeglasses.xml",
    "smile": xml_path + "haarcascade_smile.xml",
    "smile2": xml_path + "haarcascade_smile.xml"
}


class Classifier:

    def __init__(self, face_cascade_trainer, eye_cascade_trainer, smile_cascade_trainer):
        self.face_cascade = cv2.CascadeClassifier(cascade_path[face_cascade_trainer])
        self.eye_cascade = cv2.CascadeClassifier(cascade_path[eye_cascade_trainer])
        self.smile_cascade = cv2.CascadeClassifier(cascade_path[smile_cascade_trainer])
