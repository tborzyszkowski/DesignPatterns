from menu.burrito import Burrito


class BurritoVegan(Burrito):
    _name = "Vegan burrito"
    _tortilla = "wholewheat"
    _rice = "brown"
    _spice = "mild"
    _components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize"]