from menu.burrito import Burrito


class BurritoGrilledChicken(Burrito):

  def __init__(self, discount):
    self._name = "Buritto with grilled chicken"
    self._price = 15.99 * (1 - discount)
    self._tortilla = "wholewheat"
    self._rice = "basmati"
    self._spice = "moderate"
    self._components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes"]
