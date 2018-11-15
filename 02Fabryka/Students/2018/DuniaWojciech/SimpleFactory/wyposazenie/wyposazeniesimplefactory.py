from fotele import Fotele
from kierownica import Kierownica
from nawigacja import Nawigacja
from radio import Radio
from tapicerka import Tapicerka
from wyposazenie_abstract_class import Wyposazenie
import threading


class WyposazenieSimpleFactory():
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def element_wyposazenia(self, typ: str)->Wyposazenie:
        '''

        :param typ: ['blok_silnika', 'kierownica', 'nawigacja', 'radio', 'tapicerka']
        :return: Wyposazenie
        '''
        if typ == 'fotele':
            wyposazenie = Fotele({'material': 'skora'})
        elif typ == 'kierownica':
            wyposazenie = Kierownica()
        elif typ == 'nawigacja':
            wyposazenie = Nawigacja({'typ': 'GPS'})
        elif typ == 'radio':
            wyposazenie = Radio()
        elif typ == 'tapicerka':
            wyposazenie = Tapicerka({'kolor': 'czerwony'})
        else:
            wyposazenie = None
        return wyposazenie

