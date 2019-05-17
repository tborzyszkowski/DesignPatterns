from food_store import FoodStore
from menu.quesadilla import Quesadilla


class QuesadillaPulledChicken(Quesadilla):
    _name = "Quesadilla with pulled chicken"
    _tortilla = "wheat"
    _cheese = "mozzarella"
    _spice = "hot"
    _components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander", "rice"]

    def __init__(self):
      FoodStore.register_product("quesadilla_pulled_chicken", type(self))