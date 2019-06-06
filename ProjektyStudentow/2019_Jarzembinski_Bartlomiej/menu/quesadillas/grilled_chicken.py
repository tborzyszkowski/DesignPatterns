from menu.quesadilla import Quesadilla


class QuesadillaGrilledChicken(Quesadilla):

  def __init__(self, discount):
    self._name = "Quesadilla with grilled chicken"
    self._price = 12.89 * (1 - discount)
    self._tortilla = "wholewheat"
    self._cheese = "cheddar"
    self._spice = "moderate"
    self._components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes", "rice"]
