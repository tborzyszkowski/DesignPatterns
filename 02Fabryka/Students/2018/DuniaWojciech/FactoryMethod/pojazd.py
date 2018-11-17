class Pojazd:

    def __init__(self):
        self.__elementy_pojazdu = {}

    def dodaj_modul(self, obiekt: object):
        self.__elementy_pojazdu[obiekt.__class__.__name__] = obiekt

    def konfiguracja(self):
        for i, elem in self.__elementy_pojazdu.items():
            print('Moduł: {} element: {}'.format(i, elem))
