from abc import ABC, abstractmethod
from karoseria_abstract_class import Karoseria
import threading


class FabrykaKaroserii(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def karoseria_factory(self, nazwa: str)->Karoseria:
        element = self.element_karoserii(nazwa)
        element.dodaj_element()
        element.testuj()
        return element

    @abstractmethod
    def element_karoserii(self, typ: str)->Karoseria:
        """
        if typ == 'blotniki':
            karoseria = Blotniki()
        elif typ == 'drzwi':
            karoseria = Drzwi()
        elif typ == 'lakier':
            karoseria = Lakier()
        elif typ == 'maska':
            karoseria = Maska()
        elif typ == 'szyby':
            karoseria = Szyby()
        else:
            karoseria = None
        return karoseria
        """

