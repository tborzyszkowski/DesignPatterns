#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

# Proste obiekty do tworzenia przez prostą fabrykę.
class RaspberryIceCream(object):
    def try_taste(self):
        print("It's raspberry!")


class StrawberryIceCream(object):
    def try_taste(self):
        print("It's strawberry!")


class IceCreamFactory(object):
    """
    Statyczna fabryka dostarczająca odpowiednie obiekty na podstawie parametru metody get_ice_cream.
    """
    @staticmethod
    def get_ice_cream(taste):
        if taste == 'strawberry':
            return StrawberryIceCream()
        elif taste == 'raspberry':
            return RaspberryIceCream()
        raise TypeError("No such taste")

# Przykładowe wywołanie.
if __name__ == "__main__":
    factory = IceCreamFactory()
    strawb_ice = IceCreamFactory.get_ice_cream("strawberry")
    raspb_ice = IceCreamFactory.get_ice_cream("raspberry")

    [i.try_taste() for i in [strawb_ice, raspb_ice]]
