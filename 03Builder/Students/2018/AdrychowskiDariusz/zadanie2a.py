"""
Zbudować przykład problemu wytwarzania obiektów w aplikacji, dla którego lepszym rozwiązaniem (wydajnościowo,
komplikacja kodu, ...) będzie:
a) wzorzec budowniczy (raczej niż fabryka abstrakcyjna)

comment:
fabryka - Tablet z grawerunkiem
budowniczy - skladaki
"""

from abc import ABCMeta
import time


# Abstract Factory
class StandardFactory(object):

    @staticmethod
    def get_factory(factory):
        if factory == 'iPadPro':
            return iPadPro()
        elif factory == 'iPadMini':
            return iPadMini()
        raise TypeError('Unknown Factory.')


# Factory
class iPadPro(object):
    def set_text(self, tekst):
        return Pro(tekst);


class iPadMini(object):
    def set_text(self, tekst):
        return Mini(tekst);


# Product Interface
class iPad(object):
    __metaclass__ = ABCMeta

    def __init__(self, tekst):
        self.tekst = tekst

    __metaclass__ = ABCMeta

    def sell(self):
        pass


# Products
class Pro(object):
    def __init__(self, tekst):
        self.tekst = tekst

    def sell(self):
        return 'preparing iPadPro...{}'.format(self.tekst)


class Mini(object):
    def __init__(self, tekst):
        self.tekst = tekst

    def sell(self):
        return 'Preparing iPad Mini {}'.format(self.tekst)


# Director
class Director(object):
    def __init__(self):
        self.tablet = None

    def personalizuj(self):
        self.tablet.new_tablet()

    def get_tablet(self):
        return self.tablet.tekst


# Abstract Builder
class TabletAbstract(object):
    def __init__(self):
        self.tablet = None

    def new_tablet(self):
        self.tablet = Tablet()


# Concrete Builder
class MiniiPad(TabletAbstract):
    def __init__(self, tekst):
        self.tekst = tekst

    def set_text(self):
        self.tekst = ' grawerunek na mini'


# Concrete Builder
class ProiPad(TabletAbstract):
    def __init__(self, tekst):
        self.tekst = tekst

    def set_text(self):
        self.tekst = ' grawerunek na Pro'


# Product
class Tablet(object):
    def __init__(self):
        self.tekst = None

    def __repr__(self):
        return 'Grawerunek: %s ' % (self.tekst)


if __name__ == "__main__":
    start_time = time.time()
    factory = StandardFactory.get_factory('iPadPro')
    tablet = factory.set_text('ciekawy grawerunek')
    print(tablet.sell())

    factory = StandardFactory.get_factory('iPadMini')
    tablet = factory.set_text('ciekawszy grawerunek')
    print(tablet.sell())
    print("--- %s sec dla fabryki ---" % (time.time() - start_time))
    start_time = time.time()
    director = Director()
    director.tablet = MiniiPad(' grawerunek na mini')
    director.personalizuj()
    shop = director.get_tablet()
    print(shop)
    director.tablet = ProiPad(' grawerunek na Pro')
    director.personalizuj()
    shop = director.get_tablet()
    print(shop)
    print("--- %s sec dla budowniczego ---" % (time.time() - start_time))
