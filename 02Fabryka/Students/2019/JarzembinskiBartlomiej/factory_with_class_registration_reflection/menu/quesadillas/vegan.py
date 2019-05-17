from food_store import FoodStore
from menu.quesadilla import Quesadilla


class QuesadillaVegan(Quesadilla):
    _name = "Vegan quesadilla"
    _tortilla = "wholewheat"
    _cheese = "mozzarella"
    _spice = "mild"
    _components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize", "rice"]

    def __init__(self):
      FoodStore.register_product("quesadilla_vegan", type(self))