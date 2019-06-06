from menu.burrito import Burrito


class BurritoPulledChicken(Burrito):

  def __init__(self, discount):
    self._name = "Buritto with pulled chicken"
    self._price = 16.99 * (1 - discount)
    self._tortilla = "wheat"
    self._rice = "parabolic"
    self._spice = "hot"
    self._components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander"]
