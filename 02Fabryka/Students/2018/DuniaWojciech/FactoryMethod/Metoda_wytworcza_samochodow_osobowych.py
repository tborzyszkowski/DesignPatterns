from Metoda_wytworcza_silnikow import FabrykaSilnikowMetodaWytworcza
from Metoda_wytworcza_podwozia import FabrykaPodwoziaMetodaWytworcza
from Metoda_wytworcza_karoserii import FabrykaKaroseriiMetodaWytworcza
from Metoda_wytworcza_wyposazenia import FabrykaWyposazeniaMetodaWytworcza
from pojazd import Pojazd

'''
Fabryka pojazdow uzywajaca do tworzenia obiektow fabryk podzespolow takich jak:
SilnikSimpleFactory, PodwozieSimpleFactory, KaroseriaSimpleFactory, WyposazenieSimpleFactory
'''
class FabrykaSamochodowOsobowych:
    __singleton_factory = None

    def __new__(cls):
        if cls.__singleton_factory is None:
            cls.__singleton_factory = object.__new__(cls)
        return cls.__singleton_factory

    def pojazd_factory_method(self, nazwa: str)->Pojazd:
        '''
        :param nazwa: ['osobowy', 'ciezarowy']
        :return: Pojazd
        '''
        # Obiekt do ktorego beda dodawane moduly w ponizszych fabykach
        pojazd_factory = Pojazd()
        if nazwa == 'osobowy':
            # Fabryka silnikow
            fabryka = FabrykaSilnikowMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('akumulator'))
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('blok_silnika'))
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('chlodnica'))
            # Fabryka podwozia
            fabryka = FabrykaPodwoziaMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.podwozie_factory('kola'))
            pojazd_factory.dodaj_modul(fabryka.podwozie_factory('opony'))
            # Fabryka karoserii
            fabryka = FabrykaKaroseriiMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.karoseria_factory('maska'))
            pojazd_factory.dodaj_modul(fabryka.karoseria_factory('blotniki'))
            pojazd_factory.dodaj_modul(fabryka.karoseria_factory('drzwi'))
            # Fabryka wyposazenia
            fabryka = FabrykaWyposazeniaMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.wyposazenie_factory('kierownica'))
            pojazd_factory.dodaj_modul(fabryka.wyposazenie_factory('radio'))
            pojazd_factory.dodaj_modul(fabryka.wyposazenie_factory('nawigacja'))
        elif nazwa == 'ciezarowy':
            # Fabryka silnikow
            fabryka = FabrykaSilnikowMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('akumulator'))
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('blok_silnika'))
            pojazd_factory.dodaj_modul(fabryka.silnik_factory('chlodnica'))
            # Fabryka podwozia
            fabryka = FabrykaPodwoziaMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.podwozie_factory('kola'))
            # Fabryka karoserii
            fabryka = FabrykaKaroseriiMetodaWytworcza()

            pojazd_factory.dodaj_modul(fabryka.karoseria_factory('drzwi'))
            # Fabryka wyposazenia
            fabryka = FabrykaWyposazeniaMetodaWytworcza()
            pojazd_factory.dodaj_modul(fabryka.wyposazenie_factory('kierownica'))

        else:
            pojazd_factory = None
        return pojazd_factory


def main():
    print('Factory method:')
    pojazd = FabrykaSamochodowOsobowych()
    osobowy = pojazd.pojazd_factory_method('osobowy')
    ciezarowy = pojazd.pojazd_factory_method('ciezarowy')

    print('\nOsobowy')
    osobowy.konfiguracja()
    print('\nCiezarowy')
    ciezarowy.konfiguracja()


if __name__ == '__main__':
    main()
