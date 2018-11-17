from wyposazeniesimplefactory import WyposazenieSimpleFactory


class FabrykaWyposazenia:
    __singleton_factory = None

    def __init__(self, fabryka: WyposazenieSimpleFactory):
        self.__singleton_factory = fabryka

    def wyposazenie_simple_factory(self, nazwa: str)->WyposazenieSimpleFactory:
        element = self.__singleton_factory.element_wyposazenia(nazwa)
        element.dodaj_do_wyposazenia()
        element.przygotuj()
        element.testuj_element()
        return element


def main():
    prosta_fabryka_wyposazenia = WyposazenieSimpleFactory()
    fabryka = FabrykaWyposazenia(prosta_fabryka_wyposazenia)
    wytworzony_element = fabryka.wyposazenie_simple_factory('fotele')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_simple_factory('kierownica')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_simple_factory('nawigacja')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_simple_factory('radio')
    print(wytworzony_element)
    wytworzony_element = fabryka.wyposazenie_simple_factory('tapicerka')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
