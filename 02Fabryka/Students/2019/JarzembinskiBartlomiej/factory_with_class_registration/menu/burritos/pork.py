from food_store import FoodStore
from menu.burrito import Burrito


class BurritoPork(Burrito):
    _name = "Buritto with pork"
    _tortilla = "wheat"
    _rice = "brown"
    _spice = "moderate"
    _components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables"]

    def __init__(self):
      FoodStore.register_product("burrito_pork", type(self))

    @staticmethod
    def order_food():
      return BurritoPork()