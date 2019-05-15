from food_store import FoodStore
from menu.enchilada import Enchilada


class EnchiladaConCarne(Enchilada):
    _name = "Enchilada con carne"
    _tortilla = "wholewheat"
    _number_of_tortillas = 4
    _spice = "hot"
    _components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn", "rice" ]

    def __init__(self):
      FoodStore.register_product("enchilada_con_carne", type(self))