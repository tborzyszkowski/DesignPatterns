from food_store import FoodStore
from menu.burrito import Burrito


class BurritoPulledChicken(Burrito):
    _name = "Buritto with pulled chicken"
    _tortilla = "wheat"
    _rice = "parabolic"
    _spice = "hot"
    _components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander"]

    def __init__(self):
      FoodStore.register_product("burrito_pulled_chicken", type(self))

    @staticmethod
    def order_food():
      return BurritoPulledChicken()