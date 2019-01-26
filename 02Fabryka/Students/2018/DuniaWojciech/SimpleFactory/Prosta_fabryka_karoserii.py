from karoseria_simple_factory import KaroseriaSimpleFactory


class FabrykaKaroserii:
    __singleton_factory = None

    def __init__(self, fabryka: KaroseriaSimpleFactory):
        self.__singleton_factory = fabryka

    def karoseria_simple_factory(self, nazwa: str)->KaroseriaSimpleFactory:
        element = self.__singleton_factory.element_karoserii(nazwa)
        element.dodaj_element()
        element.testuj()
        return element


def main():
    prosta_fabryka_karoserii = KaroseriaSimpleFactory()
    fabryka = FabrykaKaroserii(prosta_fabryka_karoserii)
    wytworzony_element = fabryka.karoseria_simple_factory('blotniki')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_simple_factory('drzwi')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_simple_factory('lakier')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_simple_factory('maska')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_simple_factory('szyby')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
