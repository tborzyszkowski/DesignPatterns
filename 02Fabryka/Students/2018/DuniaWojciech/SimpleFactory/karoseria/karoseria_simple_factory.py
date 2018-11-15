from blotniki import Blotniki
from drzwi import Drzwi
from lakier import Lakier
from maska import Maska
from szyby import Szyby
from karoseria_abstract_class import Karoseria
import threading


class KaroseriaSimpleFactory():
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def element_karoserii(self, typ: str)->Karoseria:
        '''

        :param typ: ['blotniki', 'drzwi', 'lakier', 'maska', 'szyby']
        :return: Karoseria
        '''
        if typ == 'blotniki':
            karoseria = Blotniki({'typ': 'aluminiowe'})
        elif typ == 'drzwi':
            karoseria = Drzwi()
        elif typ == 'lakier':
            karoseria = Lakier({'typ': 'metalik'})
        elif typ == 'maska':
            karoseria = Maska()
        elif typ == 'szyby':
            karoseria = Szyby({'typ': 'mechaniczne'})
        else:
            karoseria = None
        return karoseria

