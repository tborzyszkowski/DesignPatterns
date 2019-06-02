import datetime

from functions import print_dishes_info
from factories.burrito_factory import BurritoFactory
from factories.enchilada_factory import EnchiladaFactory
from factories.quesadilla_factory import QuesadillaFactory
from singleton import Singleton

class State:
    def create_factory(self, factory_type):
        factory = None

        if factory_type == "burrito":
            factory = BurritoFactory(self.burrito_discount)
        elif factory_type == "enchilada":
            factory = EnchiladaFactory(self.enchilada_discount)
        elif factory_type == "quesadilla":
            factory = QuesadillaFactory(self.quesadilla_discount)
        else:
            factory = None
        return factory

class Monday(State):
    burrito_discount = 0.20
    enchilada_discount = 0.00
    quesadilla_discount = 0.00

class Tuesday(State):
    burrito_discount = 0.10
    enchilada_discount = 0.10
    quesadilla_discount = 0.10

class Wednesday(State):
    burrito_discount = 0.00
    enchilada_discount = 0.00
    quesadilla_discount = 0.15

class Thursday(State):
    burrito_discount = 0.00
    enchilada_discount = 0.15
    quesadilla_discount = 0.00

class Friday(State):
    burrito_discount = 0.15
    enchilada_discount = 0.00
    quesadilla_discount = 0.00

class Saturday(State):
    burrito_discount = 0.05
    enchilada_discount = 0.05
    quesadilla_discount = 0.05

class Sunday(State):
    burrito_discount = 0.05
    enchilada_discount = 0.05
    quesadilla_discount = 0.05


class Store(Singleton):
    def __init__(self):
        self.dishes_kinds = ("burrito", "enchilada", "quesadilla")
        state_name = datetime.datetime.today().strftime("%A")
        self.state = globals()[state_name]()
        if not hasattr(self, "orders_list"):
            self.orders_list = []

    def choose_dish_kind(self):
        print("Choose kind of your dish from menu:")
        print_dishes_info(self.dishes_kinds)
        chosen_dish_kind = input("Chosen dish: ")

        if chosen_dish_kind in self.dishes_kinds:
            return chosen_dish_kind
        else:
            print("We don't have such dish.\n")
            return None

    def create_factory(self, factory_type):
        return self.state.create_factory(factory_type)
