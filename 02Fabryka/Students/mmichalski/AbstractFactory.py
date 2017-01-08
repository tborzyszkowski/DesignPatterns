
class Przeciwnik:
    def akcja(self): pass

class Sojusznik:
    def walcz(self, przeciwnik): pass

class Pikinier(Sojusznik):
    def walcz(self, przeciwnik):
        print("Pikinier walczy z ")
        przeciwnik.akcja()

class Kusznik(Sojusznik):
    def walcz(self, przeciwnik):
        print("Kusznik staje do walki z ")
        przeciwnik.akcja()

class Lucznik(Przeciwnik):
    def akcja(self): print("Lucznik")

class Rycerz(Przeciwnik):
    def akcja(self): print("Rycerz")

class StworzPojedynek:
    def stworzPrzeciwnika(self): pass
    def stworzSojusznika(self): pass

# Concrete factories:
class PikinierVsLucznik(StworzPojedynek):
    def stworzPrzeciwnika(self): return Lucznik()
    def stworzSojusznika(self): return Pikinier()


class KusznikVsRycerz(StworzPojedynek):
    def stworzSojusznika(self): return Kusznik()
    def stworzPrzeciwnika(self): return Rycerz()

class PoleWalki:
    def __init__(self, factory):
        self.factory = factory
        self.sojusznik = factory.stworzSojusznika()
        self.wrog = factory.stworzPrzeciwnika()
    def rozpocznijWalke(self):
        self.sojusznik.walcz(self.wrog)

g1 = PoleWalki(PikinierVsLucznik())
g2 = PoleWalki(KusznikVsRycerz())
g1.rozpocznijWalke()
g2.rozpocznijWalke()


