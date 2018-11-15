from blok_silnika import Blok_silnika
from tloki import Tloki
from rozrusznik import Rozrusznik
from chlodnica import Chlodnica
from akumulator import Akumulator
from silnik_abstract_class import Silnik
import threading


class SilnikSimpleFactory:
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def element_silnika(self, typ: str)->Silnik:
        '''

        :param typ: ['blok_silnika', 'tloki', 'rozrusznik', 'chlodnica', 'akumulator']
        :return: Silnik
        '''
        if typ == 'blok_silnika':
            silnik = Blok_silnika({'material': 'aluminium'})
        elif typ == 'tloki':
            silnik = Tloki()
        elif typ == 'rozrusznik':
            silnik = Rozrusznik()
        elif typ == 'chlodnica':
            silnik = Chlodnica()
        elif typ == 'akumulator':
            silnik = Akumulator({'typ': '24V'})
        else: 
            silnik = None
        return silnik
