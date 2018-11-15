from abc import ABC, abstractmethod
from podwozie_abstract_class import Podwozie
import threading


class FabrykaPodwozia(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def podwozie_factory(self, nazwa: str)->Podwozie:
        element = self.element_podwozia(nazwa)
        element.dodaj_do_podwozia()
        element.testuj_podwozie()
        return element

    @abstractmethod
    def element_podwozia(self, typ: str)->Podwozie:
        """
        if typ == 'kola':
            podwozie = Kola()
        elif typ == 'opony':
            podwozie = Opony()
        elif typ == 'osie':
            podwozie = Osie()
        elif typ == 'plyta_podlogowa':
            podwozie = Plyta_podlogowa()
        elif typ == 'zawieszenie':
            podwozie = Zawieszenie()
        else:
            podwozie = None
        return podwozie
        """

