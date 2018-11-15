from kola import Kola
from opony import Opony
from osie import Osie
from plyta_podlogowa import Plyta_podlogowa
from zawieszenie import Zawieszenie
from podwozie_abstract_class import Podwozie
import threading


class PodwozieSimpleFactory():
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def element_podwozia(self, typ: str)->Podwozie:
        '''

        :param typ: ['kola', 'opony', 'osie', 'plyta_podlogowa', 'zawieszenie']
        :return:
        '''
        if typ == 'kola':
            podwozie = Kola({'rozmiar': '19'})
        elif typ == 'opony':
            podwozie = Opony()
        elif typ == 'osie':
            podwozie = Osie({'typ': 'szerokie'})
        elif typ == 'plyta_podlogowa':
            podwozie = Plyta_podlogowa()
        elif typ == 'zawieszenie':
            podwozie = Zawieszenie()
        else:
            podwozie = None
        return podwozie

