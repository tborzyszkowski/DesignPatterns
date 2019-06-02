from menu.burrito import Burrito


class BurritoConCarne(Burrito):

  def __init__(self, discount):
    self._name = "Buritto con carne"
    self._price = 17.99 * (1 - discount)
    self._tortilla = "wholewheat"
    self._rice = "jasmine"
    self._spice = "hot"
    self._components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn"]
