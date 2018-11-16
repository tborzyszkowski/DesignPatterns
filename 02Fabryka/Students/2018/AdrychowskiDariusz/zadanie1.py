"""
	Dla rozdzielenia procesu wytwarzania obiektów od klas klienta zastosować fabrykę zaimplementowaną jako singleton. 
	Zaprezentować pozytywne i negatywne skutki zastosowania:
	a) fabryki prostej
	b) fabryki z metodą wytwórczą
	c) fabryki abstrakcyjnej
"""

#simple factory

from abc import ABC, abstractmethod
from random import randint


class KontoBankowe(ABC):
	_instances = {}

	def __call__(cls, *args, **kwargs):
		if cls not in cls._instances:
			cls._instances[cls] = super(KontoFactory, cls).__call__(*args, **kwargs)
		return cls._instances[cls]

	def __init__(self):
		self.numerKonta = {}
		self.kwota = 0

	def __getitem__(self,index):
		return self.KontoBankowe[index]

	@abstractmethod
	def wplac(self, numer, kwota):
		pass
	
	@abstractmethod
	def otworzKonto(self):
		pass
	
class Osobiste(KontoBankowe):
	def __init__(self):
		pass
	
	def __getitem__(self,index):
		return self.Osobiste[index]


	def otworzKonto(self):
		numerKonta = randint(10000, 99999)
		setattr(Osobiste, str(numerKonta),0)
		return numerKonta

	def wplac(self, numerKonta, kwota):
		kwota += getattr(Osobiste,str(numerKonta))
		setattr(Osobiste, str(numerKonta),kwota)

	def balans(self, numerKonta):
		print("Dla konta o numerze {} dostepna kwota: {}".format(numerKonta,getattr(Osobiste,str(numerKonta))))


class Biznes(KontoBankowe):

	def __init__(self):
		raise Error("Not implemented yet")


class KontoFactory(object):



	def __init__(self):
		pass

	def utworz(typ):
		if typ == 'O':
			return Osobiste()
		if typ == 'B':
			return Biznes()
		assert 0, "Nieznany typ konta {}".format(typ)
	utworz = staticmethod(utworz)


if __name__ == '__main__':

	konto = KontoFactory()
	n_konto = konto.utworz('O')

	n_numerKonta = n_konto.otworzKonto()
	n_konto.wplac(n_numerKonta, 123)
	n_konto.balans(n_numerKonta)

	n_konto2 = konto.utworz('O')

	n_numerKonta2 = n_konto2.otworzKonto()
	n_konto2.wplac(n_numerKonta, 123)
	n_konto2.balans(n_numerKonta2)
	n_konto2.balans(n_numerKonta)
	print(konto,n_konto, n_konto2)
