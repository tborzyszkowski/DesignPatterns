from food_store import FoodStore
from menu.quesadilla import Quesadilla


class QuesadillaPork(Quesadilla):
    _name = "Quesadilla with pork"
    _tortilla = "wheat"
    _cheese = "mozzarella"
    _spice = "moderate"
    _components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables", "rice"]

    def __init__(self):
      FoodStore.register_product("quesadilla_pork", type(self))