class Singleton(type):
    _instances = {}

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(Singleton, cls).__call__(*args, **kwargs)
        return cls._instances[cls]


class SubSingleton1(object):
    __metaclass__ = Singleton

class SubSingleton2(object):
    __metaclass__ = Singleton

sin = SubSingleton1()
sin1 = SubSingleton1()
print(sin)
print(sin1)
sub = SubSingleton2()
sub1 = SubSingleton2()
print(sub)
print(sub1)
