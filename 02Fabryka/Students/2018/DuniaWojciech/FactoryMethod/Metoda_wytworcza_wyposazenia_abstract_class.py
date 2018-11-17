from abc import ABC, abstractmethod
from wyposazenie_abstract_class import Wyposazenie
import threading


class FabrykaWyposazenia(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def wyposazenie_factory(self, nazwa: str)->Wyposazenie:
        element = self.element_wyposazenia(nazwa)
        element.dodaj_do_wyposazenia()
        element.przygotuj()
        element.testuj_element()
        return element

    @abstractmethod
    def element_wyposazenia(self, typ: str)->Wyposazenie:
        """
        if typ == 'fotele':
            wyposazenie = Fotele()
        elif typ == 'kierownica':
            wyposazenie = Kierownica()
        elif typ == 'nawigacja':
            wyposazenie = Nawigacja()
        elif typ == 'radio':
            wyposazenie = Radio()
        elif typ == 'tapicerka':
            wyposazenie = Tapicerka()
        else:
            wyposazenie = None
        return wyposazenie
        """

