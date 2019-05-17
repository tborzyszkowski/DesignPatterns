from food_store import FoodStore
from menu.enchilada import Enchilada


class EnchiladaPork(Enchilada):
    _name = "Enchilada with pork"
    _tortilla = "wheat"
    _number_of_tortillas = 3
    _spice = "moderate"
    _components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables", "rice"]

    def __init__(self):
      FoodStore.register_product("enchilada_pork", type(self))

    @staticmethod
    def order_food():
      return EnchiladaPork()