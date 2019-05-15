from food_store import FoodStore
from menu.burrito import Burrito


class BurritoVegan(Burrito):
    _name = "Vegan burrito"
    _tortilla = "wholewheat"
    _rice = "brown"
    _spice = "mild"
    _components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize"]

    def __init__(self):
      FoodStore.register_product("burrito_vegan", type(self))