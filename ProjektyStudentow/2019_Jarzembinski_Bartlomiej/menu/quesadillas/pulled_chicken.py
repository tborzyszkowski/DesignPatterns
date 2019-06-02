from menu.quesadilla import Quesadilla


class QuesadillaPulledChicken(Quesadilla):

  def __init__(self, discount):
    self._name = "Quesadilla with pulled chicken"
    self._price = 13.89 * (1 - discount)
    self._tortilla = "wheat"
    self._cheese = "mozzarella"
    self._spice = "hot"
    self._components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander", "rice"]
