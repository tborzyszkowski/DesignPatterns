"""
Wzorując się na projektach 02VehicleBuilder i 03FluentBuilder zbudować własne buildery.\
 Buildery powinny posiadać własność FluentInterface i wykorzystywać rzutowanie konkretnego buildera na produkt
 (podobnie jak w projekcie 02VehicleBuilder). Język programowania dowolny.

"""



# Director
class Director(object):
    def __init__(self):
        self.komputer = None

    def construct_zestaw(self):
        self.komputer.nowy_komputer()
        self.komputer.monitor()
        self.komputer.stacja_dokujaca()

    def get_skladaj(self):
        return self.komputer.skladaj


# Abstract Builder
class Builder(object):
    def __init__(self):
        self.zestaw = None
        self.dod_monitor = None
        self.stacja_dok = None

    def nowy_komputer(self):
        self.zestaw = Zestawy()


# Product
class Zestawy(object):
    def __init__(self, komputer):
        self.zestaw = komputer
        self.dod_monitor = komputer.dod_monitor
        self.stacja_dok = komputer.stacja_dok

    def __repr__(self):
        return 'Moniotor: %s | Stacja dokujaca: %s' % (self.dod_monitor, self.stacja_dok)

    # Concrete Builder
    class AsemblacjaZestawu:
        def __init__(self):
            self.dod_monitor = None
            self.stacja_dok = None

        def monitor(self):
            self.dod_monitor = 'Dodatkowy monitor'
            return self

        def stacja_dokujaca(self):
            self.stacja_dok = 'Stacja dokujaca'
            return self

        def build(self):
            return Zestawy(self)

#Client
if __name__=="__main__":

    #start = Zestawy().
    produkt = Zestawy.AsemblacjaZestawu().monitor().stacja_dokujaca().build()
    produkt2 = Zestawy.AsemblacjaZestawu().monitor().build()
    produkt3 = Zestawy.AsemblacjaZestawu().stacja_dokujaca().build()
    print(produkt)
    print(produkt2)
    print(produkt3)
