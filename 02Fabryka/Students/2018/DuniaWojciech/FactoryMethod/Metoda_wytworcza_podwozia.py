from podwozie_abstract_class import Podwozie
from Metoda_wytworcza_podwozia_abstract_class import FabrykaPodwozia
from kola import Kola
from opony import Opony
from osie import Osie
from plyta_podlogowa import Plyta_podlogowa
from zawieszenie import Zawieszenie


class FabrykaPodwoziaMetodaWytworcza(FabrykaPodwozia):

    def element_podwozia(self, typ: str)->Podwozie:
        if typ == 'kola':
            podwozie = Kola()
        elif typ == 'opony':
            podwozie = Opony({'rozmiar': '19', 'szerokosc': '220'})
        elif typ == 'osie':
            podwozie = Osie()
        elif typ == 'plyta_podlogowa':
            podwozie = Plyta_podlogowa()
        elif typ == 'zawieszenie':
            podwozie = Zawieszenie({'typ': 'wahacze'})
        else:
            podwozie = None
        return podwozie


def main():
    fabryka = FabrykaPodwoziaMetodaWytworcza()
    wytworzony_element = fabryka.podwozie_factory('kola')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_factory('opony')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_factory('osie')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_factory('plyta_podlogowa')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_factory('zawieszenie')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
