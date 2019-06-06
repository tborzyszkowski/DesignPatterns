from menu.burrito import Burrito


class BurritoVegan(Burrito):

  def __init__(self, discount):
    self._name = "Vegan burrito"
    self._price = 14.99 * (1 - discount)
    self._tortilla = "wholewheat"
    self._rice = "brown"
    self._spice = "mild"
    self._components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize"]
