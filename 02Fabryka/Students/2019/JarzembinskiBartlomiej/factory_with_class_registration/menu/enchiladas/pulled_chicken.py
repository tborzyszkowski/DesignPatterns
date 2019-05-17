from food_store import FoodStore
from menu.enchilada import Enchilada


class EnchiladaPulledChicken(Enchilada):
    _name = "Enchilada with pulled chicken"
    _tortilla = "wheat"
    _number_of_tortillas = 3
    _spice = "hot"
    _components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander"]

    def __init__(self):
      FoodStore.register_product("enchilada_pulled_chicken", type(self))

    @staticmethod
    def order_food():
      return EnchiladaPulledChicken()