from multiprocessing.pool import ThreadPool
import threading


class Singleton(object):
    instance = None
    thread_lock = threading.Lock()

    def __new__(cls):
        if not isinstance(cls.instance, cls):
            with Singleton.thread_lock:
                if not isinstance(cls.instance, cls):
                    cls.instance = object.__new__(cls)
        return cls.instance


def createSingleton():
    new_singleton = Singleton()
    return new_singleton

thread1 = ThreadPool(processes=1)
thread2= ThreadPool(processes=1)

result1 = thread1.apply_async(createSingleton)
result2 = thread2.apply_async(createSingleton)

singleton1 = result1.get()
singleton2 = result2.get()

assert singleton1 is singleton2, "Created different instances, not Thread Safe."
