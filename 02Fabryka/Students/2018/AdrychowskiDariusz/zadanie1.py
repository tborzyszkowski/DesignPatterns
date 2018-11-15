"""1. Dla rozdzielenia procesu wytwarzania obiektów od klas klienta zastosować fabrykę zaimplementowaną jako singleton. 
	Zaprezentować pozytywne i negatywne skutki zastosowania:
	a) fabryki prostej
	b) fabryki z metodą wytwórczą
	c) fabryki abstrakcyjnej
"""

#simple factory

from abc import ABC, abstractmethod
from random import randint

'''
class eKontoFactory(ABC):
	
	@abstractmethod
	def sprawdzStan(self, konto):
		pass
		
	@abstractmethod
	def wyplac(self, konto, kwota)
		pass

	@abstractmethod
	def wplac(self, konto, kwota)
		pass
'''

class KontoFactory(object):
	def __init__(self):
		self.numerKonta = {}

	def utworz(self, typ):
		print()
		if typ == 'D':
			return Depozytowe()
		if typ == 'O':
			return Oszczednosciowe()
		assert 0, "Nieznany typ konta %%".format(typ)
	utworz = staticmethod(utworz)	


class Depozytowe(KontoFactory):
	def __init__(self):
		pass
	
	def utworzDepozytowe(self, nazwa, kwota):
		self.numerKonta = randint(10000, 99999)
		self.Depozytowe[self.numerKonta] = [nazwa, kwota]
		print("Stworzono konto depozytowe o nazwie %%. Numer konta to %%".format(nazwa, self.numerKonta))
		print()
		
class Oszczednosciowe(KontoFactory):
	def __init__(self):
		raise Error("Not implemented yet")

