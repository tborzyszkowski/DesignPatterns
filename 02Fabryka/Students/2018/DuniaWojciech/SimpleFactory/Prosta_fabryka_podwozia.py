from podwoziesimplefactory import PodwozieSimpleFactory


class FabrykaPodwozia:
    __singleton_factory = None

    def __init__(self, fabryka: PodwozieSimpleFactory):
        self.__singleton_factory = fabryka

    def podwozie_simple_factory(self, nazwa: str)->PodwozieSimpleFactory:
        element = self.__singleton_factory.element_podwozia(nazwa)
        element.dodaj_do_podwozia()
        element.testuj_podwozie()
        return element


def main():
    prosta_fabryka_podwozia = PodwozieSimpleFactory()
    fabryka = FabrykaPodwozia(prosta_fabryka_podwozia)
    wytworzony_element = fabryka.podwozie_simple_factory('kola')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_simple_factory('opony')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_simple_factory('osie')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_simple_factory('plyta_podlogowa')
    print(wytworzony_element)
    wytworzony_element = fabryka.podwozie_simple_factory('zawieszenie')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
