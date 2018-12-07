from abc import ABCMeta, abstractmethod
from projekt.Decorator import timer,debug,slow_down,logged

#builder

class Dml(metaclass=ABCMeta):
    @abstractmethod
    def commit(self):
        pass

class Select(Dml):
    def __init__(self):
        self.content = {}

    def action(self,kolumny):
        self.content['select'] = kolumny
        return self

    def fromm(self, skad):
        self.content['from'] = skad
        return self

    def where(self, dokad):
        self.content['where'] = dokad
        return self

    def like(self,jak):
        self.content['like'] = jak
        return self

    def commit(self):
        return QSelect(self)


class Delete(Dml):
    def __init__(self):
        self.content = {}

    def action(self,kolumny):
        self.content['delete'] = kolumny
        return self

    def fromm(self, skad):
        self.content['from'] = skad
        return self

    def where(self, dokad):
        self.content['where'] = dokad
        return self

    def like(self,jak):
        self.content['like'] = jak
        return self

    def commit(self):
        return QDelete(self)


class Update(Dml):
    def __init__(self):
        self.content = {}

    def action(self, kolumny):
        self.content['update'] = kolumny
        return self

    def set(self, co):
        self.content['set'] = co
        return self

    def fromm(self, skad):
        self.content['from'] = skad
        return self

    def where(self, dokad):
        self.content['where'] = dokad
        return self

    def like(self,jak):
        self.content['like'] = jak
        return self

    def commit(self):
        return QUpdate(self)


class Query(metaclass=ABCMeta):
    @abstractmethod
    def __init__(self):
        pass
    @abstractmethod
    def drukuj(self):
        pass

class QSelect(Query):
    def __init__(self, zapytanie: Dml):
        if 'select' in zapytanie.content:
            self.wyznacz  = zapytanie.content['select']
        self.skad = zapytanie.content['from']
        self.gdzie = zapytanie.content['where']
        self.jak = zapytanie.content['like']

    @timer
    @debug
    def drukuj(self):
        print("SELECT {} FROM {}  WHERE {}  LIKE  %{}% ;".format(self.wyznacz, self.skad, self.gdzie, self.jak))

class QDelete(Query):

    def __init__(self, zapytanie: Dml):
        if 'delete' in zapytanie.content:
            self.kasuj = zapytanie.content['delete']
        self.skad = zapytanie.content['from']
        self.gdzie = zapytanie.content['where']
        self.jak = zapytanie.content['like']

    @timer
    @debug
    @slow_down
    def drukuj(self):
        if self.kasuj:
           print("DELETE {} FROM {}  WHERE {}  LIKE  %{}% ;".format(self.kasuj,self.skad,self.gdzie,self.jak))

class QUpdate(Query):
    def __init__(self, zapytanie: Dml):
        if 'update' in zapytanie.content:
            self.aktualizuj = zapytanie.content['update']
        if 'set' in zapytanie.content:
            self.set = zapytanie.content['set']
        self.skad = zapytanie.content['from']
        self.gdzie = zapytanie.content['where']
        self.jak = zapytanie.content['like']

    @timer
    @debug
    @slow_down
    def drukuj(self):
        if self.aktualizuj:
            print("UPDATE {} SET {}  WHERE {} ;".format(self.aktualizuj, self.set, self.gdzie))








