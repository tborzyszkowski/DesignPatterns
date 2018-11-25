import time

class Singleton(object):
    class __Singleton:
        def __init__(self):
            self.val = None

        #def __str__(self):
        #    return 'self ' + self.val
    instance = None

    def __new__(cls):
        if not Singleton.instance:
            Singleton.instance = Singleton.__Singleton()
        return Singleton.instance

    def __getattr__(self, name):
        return getattr(self.instance, name)

    def __setattr__(self, name):
        return setattr(self.instance, name)


start_time = time.time()
x = Singleton()
y = Singleton()
z = Singleton()
print(y)
print(z)
print(x)
print("--- %s seconds ---" % (time.time() - start_time))
