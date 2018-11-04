class Singleton(type):
    _instances = {}
    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(Singleton, cls).__call__(*args, **kwargs)
        return cls._instances[cls]


class PgDB(metaclass=Singleton):
    def tellme(self):
        pass

class MyDB(metaclass=Singleton):
    def tellme(self):
        pass

s1 = PgDB()
s2 = PgDB()
print(s1)
print(s2)

