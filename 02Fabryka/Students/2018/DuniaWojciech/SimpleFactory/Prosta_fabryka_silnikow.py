from silniksimplefactory import SilnikSimpleFactory


class FabrykaSilnikow:
    __singleton_factory = None

    def __init__(self, fabryka: SilnikSimpleFactory):
        self.__singleton_factory = fabryka

    def silnik_simple_factory(self, nazwa: str)->SilnikSimpleFactory:
        element = self.__singleton_factory.element_silnika(nazwa)
        element.dodaj_do_silnika()
        element.testuj()
        element.uruchom()
        return element


def main():
    prosta_fabryka_silnikow = SilnikSimpleFactory()
    fabryka = FabrykaSilnikow(prosta_fabryka_silnikow)
    wytworzony_element = fabryka.silnik_simple_factory('akumulator')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_simple_factory('blok_silnika')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_simple_factory('chlodnica')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_simple_factory('rozrusznik')
    print(wytworzony_element)
    wytworzony_element = fabryka.silnik_simple_factory('tloki')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
