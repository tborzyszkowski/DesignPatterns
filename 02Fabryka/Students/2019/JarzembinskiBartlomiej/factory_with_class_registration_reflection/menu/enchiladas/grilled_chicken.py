from food_store import FoodStore
from menu.enchilada import Enchilada


class EnchiladaGrilledChicken(Enchilada):
    _name = "Enchilada with grilled chicken"
    _tortilla = "wholewheat"
    _number_of_tortillas = 3
    _spice = "moderate"
    _components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes"]

    def __init__(self):
      FoodStore.register_product("enchilada_grilled_chicken", type(self))