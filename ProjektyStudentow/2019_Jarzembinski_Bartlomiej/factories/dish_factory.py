from abc import ABC, abstractmethod
from functions import print_dishes_info
from order import Order
from threading import Lock


class DishFactory(ABC):
    _instances = {}
    _threading_lock = Lock()

    def __init__(self, discount):
        self.dishes_types = ("con_carne", "grilled_chicken", "pork", "pulled_chicken", "vegan")
        self.discount = discount

    def __new__(cls, discount):
        if type(object.__new__(cls)).__name__ not in cls._instances:
            with cls._threading_lock:
                if type(object.__new__(cls)).__name__ not in cls._instances:
                    cls._instances[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls._instances[type(object.__new__(cls)).__name__]

    @abstractmethod
    def create_dish(self, dish_type):
        pass

    def order_dish(self):
        print("\nNow, choose type of your dish, today we serves following types:")
        print_dishes_info(self.dishes_types)
        chosen_dish_type = input("Chosen dish type: ")

        if chosen_dish_type in self.dishes_types:
            dish = self.create_dish(chosen_dish_type)
            order = Order(dish)
            return order
        else:
            print("We don't have such dish.\n")
            return None
