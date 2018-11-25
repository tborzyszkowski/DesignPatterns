from abc import ABC, abstractmethod
from abstrakcyjna_fabryka_czesci_abstract_class import AbstrakcyjnaFabrykaCzesci
import threading

class AbstrakcyjnaFabrykaSamochodow(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls, fabryka_czesci: AbstrakcyjnaFabrykaCzesci):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def __init__(self, fabryka_czesci: AbstrakcyjnaFabrykaCzesci):
        self.fabryka_czesci = fabryka_czesci
        self.fabryka_karoserii = None
        self.fabryka_podwozia = None
        self.fabryka_silnika = None
        self.fabryka_wyposazenia = None

    @abstractmethod
    def wytworz_samochod(self):
        pass
        '''
        self.__fabryka_karoserii = self.__fabryka_czesci.wytworz_karoserie()
        self.__fabryka_podwozia = self.__fabryka_czesci.wytworz_podwozie()
        self.__fabryka_silnika = self.__fabryka_czesci.wytworz_silnik()
        self.__fabryka_wyposazenia = self.__fabryka_czesci.wytworz_wyposazenie()
        '''

    # Po wytworzeniu wyswietla specyfikacje
    def specyfikacja_samochodu(self):
        print(self.fabryka_karoserii)
        print(self.fabryka_podwozia)
        print(self.fabryka_silnika)
        print(self.fabryka_wyposazenia)

