from wyposazenie_abstract_class import Wyposazenie
from Metoda_wytworcza_wyposazenia_abstract_class import FabrykaWyposazenia
from fotele import Fotele
from kierownica import Kierownica
from nawigacja import Nawigacja
from radio import Radio
from tapicerka import Tapicerka


class FabrykaWyposazeniaMetodaWytworcza(FabrykaWyposazenia):
    def element_wyposazenia(self, typ: str)->Wyposazenie:
        if typ == 'fotele':
            wyposazenie = Fotele({'typ': 'skorzane'})
        elif typ == 'kierownica':
            wyposazenie = Kierownica({'typ': 'skorzana'})
        elif typ == 'nawigacja':
            wyposazenie = Nawigacja()
        elif typ == 'radio':
            wyposazenie = Radio()
        elif typ == 'tapicerka':
            wyposazenie = Tapicerka({'typ': 'welurowa'})
        else:
            wyposazenie = None
        return wyposazenie


def main():
    fabryka = FabrykaWyposazeniaMetodaWytworcza()
    wytworzony_element = fabryka.wyposazenie_factory('fotele')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_factory('kierownica')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_factory('nawigacja')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_factory('radio')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_factory('tapicerka')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
