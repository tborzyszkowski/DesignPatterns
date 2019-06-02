from menu.quesadilla import Quesadilla


class QuesadillaConCarne(Quesadilla):

  def __init__(self, discount):
    self._name = "Quesadilla con carne"
    self._price = 13.89 * (1 - discount)
    self._tortilla = "wholewheat"
    self._cheese = "cheddar"
    self._spice = "hot"
    self._components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn", "rice" ]
