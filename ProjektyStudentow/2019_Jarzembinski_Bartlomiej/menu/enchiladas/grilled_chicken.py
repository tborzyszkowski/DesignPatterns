from menu.enchilada import Enchilada


class EnchiladaGrilledChicken(Enchilada):

  def __init__(self, discount):
    self._name = "Enchilada with grilled chicken"
    self._price = 17.55 * (1 - discount)
    self._tortilla = "wholewheat"
    self._number_of_tortillas = 3
    self._spice = "moderate"
    self._components = ["grilled chicken", "pinto beans", "lettuce", "cheddar", "tomatoes"]
