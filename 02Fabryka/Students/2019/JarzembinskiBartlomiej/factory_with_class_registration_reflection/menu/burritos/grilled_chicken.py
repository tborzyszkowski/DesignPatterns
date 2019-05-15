from food_store import FoodStore
from menu.burrito import Burrito


class BurritoGrilledChicken(Burrito):
    _name = "Buritto with grilled chicken"
    _tortilla = "wholewheat"
    _rice = "basmati"
    _spice = "moderate"
    _components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes"]

    def __init__(self):
      FoodStore.register_product("burrito_grilled_chicken", type(self))