from menu.quesadilla import Quesadilla


class QuesadillaVegan(Quesadilla):

  def __init__(self, discount):
    self._name = "Vegan quesadilla"
    self._price = 12.89 * (1 - discount)
    self._tortilla = "wholewheat"
    self._cheese = "mozzarella"
    self._spice = "mild"
    self._components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize", "rice"]
