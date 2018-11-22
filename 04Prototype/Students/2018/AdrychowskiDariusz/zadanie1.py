from abc import ABC, abstractmethod
import copy


class Komputer(ABC):
    def __init__(self):
        self.id = None
        self.typ = None

    @abstractmethod
    def konfiguruj(self):
        pass

    def get_typ(self):
        return self.typ

    def get_id(self):
        return self.id

    def set_id(self, sid):
        self.id = sid

    def clone(self):
        return copy.copy(self)


class HP_Blade(Komputer):
    def __init__(self):
        super().__init__()
        self.typ = "HP Blade Server"

    def konfiguruj(self):
        print("Inside HP Blade Server::konfiguruj() method.")


class IBM_mainframe(Komputer):
    def __init__(self):
        super().__init__()
        self.typ = "IBM mainframe"

    def konfiguruj(self):
        print("Inside IBM mainframeare::kuonfiguruj() method.")


class Dell(Komputer):
    def __init__(self):
        super().__init__()
        self.typ = "Dell"

    def konfiguruj(self):
        print("Inside Dell::konfiguruj() method.")


class KomputerCache:
    cache = {}

    @staticmethod
    def get_komputer(sid):
        komputer = KomputerCache.cache.get(sid, None)
        return komputer.clone()

    @staticmethod
    def load():
        dell = Dell()
        dell.set_id("1")
        KomputerCache.cache[dell.get_id()] = dell

        mainframe = IBM_mainframe()
        mainframe.set_id("2")
        KomputerCache.cache[mainframe.get_id()] = mainframe

        serwer = HP_Blade()
        serwer.set_id("3")
        KomputerCache.cache[serwer.get_id()] = serwer


if __name__ == '__main__':
    KomputerCache.load()

    dell = KomputerCache.get_komputer("1")
    print(dell.get_typ())

    mainframe = KomputerCache.get_komputer("2")
    print(mainframe.get_typ())

    serwer = KomputerCache.get_komputer("3")
    print(serwer.get_typ())
