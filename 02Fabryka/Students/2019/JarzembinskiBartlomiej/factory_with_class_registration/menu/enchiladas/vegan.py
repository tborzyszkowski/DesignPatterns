from food_store import FoodStore
from menu.enchilada import Enchilada


class EnchiladaVegan(Enchilada):
    _name = "Vegan enchilada"
    _tortilla = "wholewheat"
    _number_of_tortillas = 4
    _spice = "mild"
    _components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize", "rice"]

    def __init__(self):
      FoodStore.register_product("enchilada_vegan", type(self))

    @staticmethod
    def order_food():
      return EnchiladaVegan()