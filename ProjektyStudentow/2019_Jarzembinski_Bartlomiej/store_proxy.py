import sys

from singleton import Singleton
from store import Store


class StoreProxy(Singleton):
    def create_store(self):
        print("What's time is it? (store is open between 9:00am and 10:00pm)")
        input_time = input("Current time: ")

        if len(input_time) == 5:
            current_time = int(input_time[0:2])
        else:
            current_time = int(input_time[0:1])

        if current_time > 8 and current_time < 22:
            return Store()
        else:
            print("Store is closed!\n")
            return None
