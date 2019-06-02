from menu.enchilada import Enchilada


class EnchiladaPulledChicken(Enchilada):

  def __init__(self, discount):
    self._name = "Enchilada with pulled chicken"
    self._price = 17.55 * (1 - discount)
    self._tortilla = "wheat"
    self._number_of_tortillas = 3
    self._spice = "hot"
    self._components = ["pulled chicken", "lettuce", "roasted peppers", "pint beans", "coriander"]
