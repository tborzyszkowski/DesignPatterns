import cv2
# from image import Image
from detector import Detector
from classifier import Classifier
import time
import camera as cam
import cameraProxy as cameraAv
from obserwator import Subject  # , ConcreteObserver
from silnik import Silnik
from SilnikXObser import SilnikXObserver, SilnikYObserver
from mediator import ConcreteMediator, ConcreteOperator

import logging
import sys

# logg
logger = logging.getLogger()
logger.setLevel(logging.DEBUG)
handler = logging.StreamHandler(sys.stdout)
handler.setLevel(logging.DEBUG)
formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
handler.setFormatter(formatter)
logger.addHandler(handler)

# obserwator

silnik_x = Subject('X')
obserwator_x = SilnikXObserver()
silnik_x.attach(obserwator_x)

silnik_y = Subject('Y')
obserwator_y = SilnikYObserver()
silnik_y.attach(obserwator_y)

# mediator

mediator = ConcreteMediator()

stReczne = ConcreteOperator(mediator, 1)
stAutomatyczne = ConcreteOperator(mediator, 2)

mediator.add(stReczne)
mediator.add(stAutomatyczne)
# camera proxy

check = cameraAv.Proxy()
cam = check.availablility()
if cam.access:
    print("Using camera id: {}".format(cam.presentCamera))
    cam1 = cam.cam1
    cam1.prepare(cam.presentCamera)
    haarcascade_classifier = Classifier("alt2", "eye_glasses", "smile")
    font = cv2.FONT_HERSHEY_SIMPLEX
    komenda = ""

    while True:
        komenda = ""
        frame = cam1.singleFrame()
        detector = Detector(frame, 1.1, 5, (30, 30), cv2.DIST_L2, haarcascade_classifier)

        key = cv2.waitKey(30) & 0xff
        if key == 49:
            komenda = "Wyszukiwanie manualne"
            stReczne.send(komenda)
            silnik_x.subject_state = 1
        elif key == 50:
            silnik_x.subject_state = -1
        elif key == 30:
            silnik_y.subject_state = 1
        elif key == 32:
            silnik_y.subject_state = -1
            komenda = "Wyszukiwanie manualne"
            stReczne.send(komenda)

        a = detector.detect()
        if a:
            try:
                window_x = cv2.getWindowImageRect("Video")[2]
                window_y = cv2.getWindowImageRect("Video")[3]
            except:
                window_x = 640
                window_y = 480
            # print(list(enumerate(a["faces"])))
            # print(a["faces"][0].wspol_x(),",",a["faces"][0].wspol_y())
            komenda = "Namierzanie automatyczne... "
            stAutomatyczne.send(komenda)

            silnik_x.subject_state = a["faces"][0].wspol_x() - (window_x / 2)
            silnik_y.subject_state = a["faces"][0].wspol_y() - (window_y / 2)

            if obserwator_x._observer_state < 0:
                komenda += "->"
            elif obserwator_x._observer_state > 0:
                komenda += "<-"
            else:
                komenda += "--"
            if obserwator_y._observer_state < 0:
                komenda = komenda + "^"
            elif obserwator_y._observer_state > 0:
                komenda = komenda + "v"
            else:
                komenda = komenda + "|"
            cv2.putText(frame, komenda, (230, 50), font, 0.5, (0, 255, 0), 2, cv2.LINE_AA)

        cv2.imshow("Video", frame)
        key = cv2.waitKey(30) & 0xff
        if key == 27:
            cam1.endRecording()
            break
