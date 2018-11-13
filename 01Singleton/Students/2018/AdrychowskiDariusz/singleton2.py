import time


class Singleton:
    __instance = None

    def __new__(cls, *args, **kwargs):
        if not cls.__instance:
            cls.__instance = super(Singleton, cls).__new__(cls, *args, **kwargs)
        return cls.__instance

class MySingleton(Singleton):

    def foo(self):
        pass

    def __getattr__(self, name):
        return getattr(self, name)

    def __setattr__(self, name):
        return setattr(self, name)


start_time = time.time()
x = MySingleton()
y = MySingleton()
z = MySingleton()
#x.val = 'test'
print('x', x)
print('y', y)
print('z', z)
print("--- %s seconds ---" % (time.time() - start_time))

