from silniksimplefactory import SilnikSimpleFactory
from podwoziesimplefactory import PodwozieSimpleFactory
from karoseria_simple_factory import KaroseriaSimpleFactory
from wyposazeniesimplefactory import WyposazenieSimpleFactory
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

    def pojazd_simple_factory(self, nazwa: str)->Pojazd:
        '''
        :param nazwa: ['osobowy', 'ciezarowy']
        :return: Pojazd
        '''
        # Obiekt do ktorego beda dodawane moduly w ponizszych fabykach
        pojazd_factory = Pojazd()
        if nazwa == 'osobowy':
            # Fabryka silnikow
            silnik = SilnikSimpleFactory()
            pojazd_factory.dodaj_modul(silnik.element_silnika('akumulator'))
            pojazd_factory.dodaj_modul(silnik.element_silnika('blok_silnika'))
            pojazd_factory.dodaj_modul(silnik.element_silnika('tloki'))
            # Fabryka podwozia
            podwozie = PodwozieSimpleFactory()
            pojazd_factory.dodaj_modul(podwozie.element_podwozia('osie'))
            pojazd_factory.dodaj_modul(podwozie.element_podwozia('opony'))
            # Fabryka karoserii
            karoseria = KaroseriaSimpleFactory()
            pojazd_factory.dodaj_modul(karoseria.element_karoserii('maska'))
            pojazd_factory.dodaj_modul(karoseria.element_karoserii('blotniki'))
            pojazd_factory.dodaj_modul(karoseria.element_karoserii('drzwi'))
            # Fabryka wyposazenia
            wyposazenie = WyposazenieSimpleFactory()
            pojazd_factory.dodaj_modul(wyposazenie.element_wyposazenia('kierownica'))
            pojazd_factory.dodaj_modul(wyposazenie.element_wyposazenia('radio'))
            pojazd_factory.dodaj_modul(wyposazenie.element_wyposazenia('nawigacja'))
        elif nazwa == 'ciezarowy':
            # Fabryka silnikow
            silnik = SilnikSimpleFactory()
            pojazd_factory.dodaj_modul(silnik.element_silnika('akumulator'))
            pojazd_factory.dodaj_modul(silnik.element_silnika('blok_silnika'))
            pojazd_factory.dodaj_modul(silnik.element_silnika('tloki'))
            # Fabryka podwozia
            podwozie = PodwozieSimpleFactory()
            pojazd_factory.dodaj_modul(podwozie.element_podwozia('kola'))
            pojazd_factory.dodaj_modul(podwozie.element_podwozia('opony'))
            # Fabryka karoserii
            karoseria = KaroseriaSimpleFactory()
            pojazd_factory.dodaj_modul(karoseria.element_karoserii('drzwi'))
            # Fabryka wyposazenia
            wyposazenie = WyposazenieSimpleFactory()
            pojazd_factory.dodaj_modul(wyposazenie.element_wyposazenia('kierownica'))
        else:
            pojazd_factory = None
        return pojazd_factory


def main():
    print('Simple factory:')
    pojazd = FabrykaSamochodowOsobowych()
    osobowy = pojazd.pojazd_simple_factory('osobowy')
    ciezarowy = pojazd.pojazd_simple_factory('ciezarowy')

    print('\nOsobowy')
    osobowy.konfiguracja()
    print('\nCiezarowy')
    ciezarowy.konfiguracja()


if __name__ == '__main__':
    main()
