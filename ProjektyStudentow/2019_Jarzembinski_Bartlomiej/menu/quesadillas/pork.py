from menu.quesadilla import Quesadilla


class QuesadillaPork(Quesadilla):

  def __init__(self, discount):
    self._name = "Quesadilla with pork"
    self._price = 13.89 * (1 - discount)
    self._tortilla = "wheat"
    self._cheese = "mozzarella"
    self._spice = "moderate"
    self._components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables", "rice"]
