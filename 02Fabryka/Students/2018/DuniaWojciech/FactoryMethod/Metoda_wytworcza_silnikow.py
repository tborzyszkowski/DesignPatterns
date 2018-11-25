from silnik_abstract_class import Silnik
from Metoda_wytworcza_silnikow_abstract_class import FabrykaSilnikow
from blok_silnika import Blok_silnika
from tloki import Tloki
from rozrusznik import Rozrusznik
from chlodnica import Chlodnica
from akumulator import Akumulator


class FabrykaSilnikowMetodaWytworcza(FabrykaSilnikow):
    def element_silnika(self, typ: str)->Silnik:
        if typ == 'blok_silnika':
            silnik = Blok_silnika({'material': 'magnez'})
        elif typ == 'tloki':
            silnik = Tloki()
        elif typ == 'rozrusznik':
            silnik = Rozrusznik()
        elif typ == 'chlodnica':
            silnik = Chlodnica({'rodzaj': 'aluminiowa'})
        elif typ == 'akumulator':
            silnik = Akumulator()
        else:
            silnik = None
        return silnik


def main():
    fabryka = FabrykaSilnikowMetodaWytworcza()
    wytworzony_element = fabryka.silnik_factory('akumulator')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_factory('blok_silnika')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_factory('chlodnica')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_factory('rozrusznik')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_factory('tloki')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
