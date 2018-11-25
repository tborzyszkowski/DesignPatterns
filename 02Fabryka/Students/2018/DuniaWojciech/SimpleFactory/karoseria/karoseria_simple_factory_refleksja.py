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
        """ Implementacja rejestracji klas z uzyciem refleksji """

        # Funkcje nadpisujące metody abstrakcyjne w nadklasie
        def dodaj_element(self):
            pass

        def testuj(self):
            pass

        def usun_element(self):
            pass

        klasa = type(typ, (Karoseria,), {"dodaj_element": dodaj_element,
                                         "testuj": testuj,
                                         "usun_element": usun_element})
        if typ not in globals():
            globals()[typ] = klasa
        karoseria = klasa()
        return karoseria

