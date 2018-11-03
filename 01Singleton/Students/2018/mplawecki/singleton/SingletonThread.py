from multiprocessing.pool import ThreadPool


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


@Singleton
class Watcher(object):
    def __init__(self, *args):
        pass


pool = ThreadPool(4)
results = [pool.apply_async(Watcher) for _ in range(4)]
instances = [r.get() for r in results]

for i in instances:
   print(i)