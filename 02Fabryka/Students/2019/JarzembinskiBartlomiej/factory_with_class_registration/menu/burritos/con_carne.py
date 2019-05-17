from food_store import FoodStore
from menu.burrito import Burrito


class BurritoConCarne(Burrito):
    _name = "Buritto con carne"
    _tortilla = "wholewheat"
    _rice = "jasmine"
    _spice = "hot"
    _components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn"]

    def __init__(self):
      FoodStore.register_product("burrito_con_carne", type(self))

    @staticmethod
    def order_food():
      return BurritoConCarne()