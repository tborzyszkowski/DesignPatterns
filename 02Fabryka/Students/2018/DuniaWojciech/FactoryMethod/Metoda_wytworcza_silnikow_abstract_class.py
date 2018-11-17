from abc import ABC, abstractmethod
from silnik_abstract_class import Silnik
import threading


class FabrykaSilnikow(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def silnik_factory(self, nazwa: str)->Silnik:
        element = self.element_silnika(nazwa)
        element.dodaj_do_silnika()
        element.testuj()
        element.uruchom()
        return element

    @abstractmethod
    def element_silnika(self, typ: str)->Silnik:
        """
        if typ == 'blok_silnika':
            silnik = Blok_silnika()
        elif typ == 'tloki':
            silnik = Tloki()
        elif typ == 'rozrusznik':
            silnik = Rozrusznik()
        elif typ == 'chlodnica':
            silnik = Chlodnica()
        elif typ == 'akumulator':
            silnik = Akumulator()
        else:
            silnik = None
        return silnik
        """


