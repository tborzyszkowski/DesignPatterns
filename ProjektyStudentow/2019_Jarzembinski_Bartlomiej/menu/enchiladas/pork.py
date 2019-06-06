from menu.enchilada import Enchilada


class EnchiladaPork(Enchilada):

  def __init__(self, discount):
    self._name = "Enchilada with pork"
    self._price = 17.55
    self._tortilla = "wheat"
    self._number_of_tortillas = 3
    self._spice = "moderate"
    self._components = ["pork", "tomatoes", "black beans", "cottage cheese", "grilled vegetables", "rice"]
