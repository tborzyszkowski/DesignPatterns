from food_store import FoodStore
from menu.quesadilla import Quesadilla


class QuesadillaConCarne(Quesadilla):
    _name = "Quesadilla con carne"
    _tortilla = "wholewheat"
    _cheese = "cheddar"
    _spice = "hot"
    _components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn", "rice" ]

    def __init__(self):
      FoodStore.register_product("quesadilla_con_carne", type(self))