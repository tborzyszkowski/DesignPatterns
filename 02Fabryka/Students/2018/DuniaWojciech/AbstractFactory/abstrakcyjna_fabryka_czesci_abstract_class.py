from abc import ABC, abstractmethod
from karoseria_abstract_class import Karoseria
from podwozie_abstract_class import Podwozie
from silnik_abstract_class import Silnik
from wyposazenie_abstract_class import Wyposazenie
from typing import List
import threading

class AbstrakcyjnaFabrykaCzesci(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    @abstractmethod
    def wytworz_karoserie(self)->List[Karoseria]:
        pass

    @abstractmethod
    def wytworz_podwozie(self)->List[Podwozie]:
        pass

    @abstractmethod
    def wytworz_silnik(self)->List[Silnik]:
        pass

    @abstractmethod
    def wytworz_wyposazenie(self)->List[Wyposazenie]:
        pass
