'''
import threading


class Singleton(object):
    threadingLock = threading.Lock()
    instance = None

    def __new__(self):
        if not self.instance:
            with Singleton.threadingLock:
                if not self.instance:
                    self.instance = object.__new__(self)
        return self.instance


class SubSingleton(Singleton):
    def __new__(self):
        return super(SubSingleton, self).__new__(self)
'''


class Singleton(object):
    class __Singleton:
        def __init__(self, arg):
            self.val = arg

        def __str__(self):
            return repr(self) + self.val
    instance = None

    def __new__(cls):
        if not Singleton.instance:
            Singleton.instance = Singleton.__Singleton()
        return Singleton.instance

    def __getattr__(self, name):
        return getattr(self.instance, name)

    def __setattr__(self, name):
        return setattr(self.instance, name)


x = Singleton('test')
print(x)
y = Singleton('test2')
print(y)



class OnlyOne(object):
    class __OnlyOne:
        def __init__(self):
            self.val = None
        def __str__(self):
            return `self` + self.val
    instance = None
    def __new__(cls): # __new__ always a classmethod
        if not OnlyOne.instance:
            OnlyOne.instance = OnlyOne.__OnlyOne()
        return OnlyOne.instance
    def __getattr__(self, name):
        return getattr(self.instance, name)
    def __setattr__(self, name):
        return setattr(self.instance, name)
