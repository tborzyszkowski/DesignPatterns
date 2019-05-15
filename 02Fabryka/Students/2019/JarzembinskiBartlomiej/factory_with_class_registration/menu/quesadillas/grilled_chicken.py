from food_store import FoodStore
from menu.quesadilla import Quesadilla


class QuesadillaGrilledChicken(Quesadilla):
    _name = "Quesadilla with grilled chicken"
    _tortilla = "wholewheat"
    _cheese = "cheddar"
    _spice = "moderate"
    _components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes", "rice"]

    def __init__(self):
      FoodStore.register_product("quesadilla_grilled_chicken", type(self))

    @staticmethod
    def order_food():
      return QuesadillaGrilledChicken()