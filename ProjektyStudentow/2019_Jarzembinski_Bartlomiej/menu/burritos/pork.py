from menu.burrito import Burrito


class BurritoPork(Burrito):

  def __init__(self, discount):
    self._name = "Buritto with pork"
    self._price = 16.99 * (1 - discount)
    self._tortilla = "wheat"
    self._rice = "brown"
    self._spice = "moderate"
    self._components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables"]
