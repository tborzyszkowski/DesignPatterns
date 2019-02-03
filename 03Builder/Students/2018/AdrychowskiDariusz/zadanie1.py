'''
Wzorując się na projektach 02VehicleBuilder i 03FluentBuilder zbudować własne buildery.\
 Buildery powinny posiadać własność FluentInterface i wykorzystywać rzutowanie konkretnego buildera na produkt
 (podobnie jak w projekcie 02VehicleBuilder). Język programowania dowolny.

 https://en.proft.me/2016/09/25/builder-design-pattern-java-and-python/

 https://python-patterns.guide/gang-of-four/builder/
https://gist.github.com/pazdera/1121157
https://github.com/adrych/python-patterns/blob/master/creational/builder.py

'''

from enum import Enum
from abc import ABC, abstractmethod
import time

PrzelewStan = Enum('PrzelewStan','Do realizacji Oczekuje Transfer Zrealizowany')


Opoznienie = 3


class Przelew:
    def __init__(self, name):
        self.name = name
        self.z_konta = None
        self.na_konto = None
        self.zagraniczny = None
        self.SplitPayment = None
        self.zlecajacyPlaci = None
        self.obiorcePlaci = None


    def setZkonta(self,name):
        self.z_konta = name

    def getZkonta(self):
        return self.z_konta

    def setNaKonto(self,name):
        self.na_konto = name

    def getNaKonto(self,name):
        return self.na_konto

    def setZagraniczny(self,op):
        self.zagraniczny = op

    def getZagraniczny(self):
        return self.zagraniczny

    def setSplitPayment(self, op):
        self.SplitPayment = op

    def getSplitPayment(self):
        return self.SplitPayment

    def setZlecajacyPlaci(self, op):
        self.zlecajacyPlaci = op

    def getZlecajacyPlaci(self):
        return self.zlecajacyPlaci

    def __str__(self):
        return self.name


class PrzelewBuilder(ABC):
    @abstractmethod
    def get_result(self):
        pass


class PrzelewBuilderImpl(PrzelewBuilder):
    def __init__(self):
        self.przelew = Przelew()

    def setZkonta(self, name):
        self.przelew.setZkonta(name)

    def getZKonta(self):
        self.przelew.getZkonta()

    def setNaKonto(self, name):
        self.przelew.setNaKonto(name)

    def getNaKonto(self, name):
        return self.przelew.getNaKonto()

    def setZagraniczny(self, op):
        self.przelew.setZagraniczny(op)

    def getZagraniczny(self):
        return self.przelew.getZagraniczny()

    def setSplitPayment(self, op):
        self.przelew.setSplitPayment(op)

    def getSplitPayment(self):
        return self.przelew.getSplitPayment()

    def setZlecajacyPlaci(self, op):
        self.przelew.setZlecajacyPlaci(op)

    def getZlecajacyPlaci(self):
        return self.przelew.getZlecajacyPlaci()


class PrzelewDirector:
    def __init__(self, builder):
        self.builder = builder

    def constructor(self):
        self.builder.set

class PrzelewKrajowyBuilder:
    def __init__(self):
        self.zagraniczny = Przelew('Krajowy')



