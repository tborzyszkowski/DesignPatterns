from abc import ABCMeta, abstractmethod
from projekt.Config import Config


#singleton
def Singleton(cls):
    import threading
    lock = threading.RLock()
    instances = {}

    def create(*args):
        with lock:
            try:
                return instances[args]
            except KeyError:
                instances[args] = instance = cls(*args)
                return instance

    return create


#iterator
class GiveInt:
   def __init__(self, low, high):
      self.current = low
      self.high = high

   def __iter__(self):
      return self

   def __next__(self):
      if self.current > self.high:
         raise StopIteration
      else:
         self.current += 1
      return self.current - 1


class DBAPI(metaclass=ABCMeta):

    @abstractmethod
    def close_conn(self):
        pass
    @abstractmethod
    def connect(self):
        pass

@Singleton
class MySQLdbAPI(DBAPI):


    def close_conn(self):
        print("Closing connection to mysql database")

    def connect(self):
        print("Connect to mysql database ...")
    @staticmethod
    def __str__():
        return 'mysql'


@Singleton
class PgSQLAPI(DBAPI):


    def close_conn(self):
        print("Closing connection to postgres database")

    def connect(self):
        print("Connect to postgres database ...")
    @staticmethod
    def __str__():
        return 'postgres'

@Singleton
class Sqlite3API(DBAPI):
    def close_conn(self):
        print("Closing connection to sqlite database")

    def connect(self):
        print("Connect to sqlite database ...")

    @staticmethod
    def __str__():
        return 'sqlite'

#proxy
class Transaction(object):
    def __init__(self):
        self.trans = {}
        self.getuid = iter(GiveInt(1, 100000))

    def addTrans(self,query):
        self.trans[next(self.getuid)] = query

    def showTrans(self):
        return self.trans


class Database(DBAPI):
    def __init__(self, db):
        self.db = db()
        self.trans = Transaction()
        self.config = Config(db)

    def close_conn(self):
        return self.db.close_conn()

    def connect(self):
        return self.db.connect()

    def show_config(self):
        return self.config.getConfig()


