import threading
from multiprocessing.pool import ThreadPool

class TFSingleton(object):
    _instance = None
    _lock = threading.Lock()

    def __new__(cls):
        if TFSingleton._instance is None:
            with TFSingleton._lock:
                if TFSingleton._instance is None:
                    TFSingleton._instance = super(TFSingleton, cls).__new__(cls)
        return TFSingleton._instance

    def __init__(self):
        self.clients = []


def func():
    sin = TFSingleton()
    return sin

def func1():
    sin1 = TFSingleton()
    return sin1

pool = ThreadPool(processes=1)
pool1 = ThreadPool(processes=1)


async_result = pool.apply_async(func)
async_result1 = pool1.apply_async(func1)

sin = async_result.get()
sin1 = async_result1.get(())

if sin is sin1:
    print("ok")
else:
    print("nok")
