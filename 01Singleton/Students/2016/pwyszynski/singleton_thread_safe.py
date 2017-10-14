#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

import threading


class SingletonBase(object):
    __lock = threading.Lock()
    __instance = None

    @classmethod
    def instance(cls):
        if not cls.__instance:
            with cls.__lock:
                if not cls.__instance:
                    print("Tworze nowa instancje!")
                    cls.__instance = cls()
                else:
                    print("Singleton juz istnieje, nie tworze nowego.")
        else:
            print("Singleton juz istnieje, nie tworze nowego.")
        return cls.__instance


if __name__ == '__main__':
    class Pierwszy(SingletonBase):
        def do_something(self):
            print("Robie cos.")


    class Drugi(SingletonBase):
        def do_something_else(self):
            print("Robie cos innego.")


    a, a2 = Pierwszy.instance(), Pierwszy.instance()
    b, b2 = Drugi.instance(), Drugi.instance()

    thread = threading.Thread(target=a.do_something)
    thread3 = threading.Thread(target=a2.do_something)
    thread2 = threading.Thread(target=b.do_something_else)
    thread.start()
    thread2.start()
    thread3.start()
    thread3.join()
    thread2.join()
    thread.join()
    print("Threads finished.")
