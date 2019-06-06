from menu.enchilada import Enchilada


class EnchiladaVegan(Enchilada):

  def __init__(self, discount):
    self._name = "Vegan enchilada"
    self._price = 16.55 * (1 - discount)
    self._tortilla = "wholewheat"
    self._number_of_tortillas = 4
    self._spice = "mild"
    self._components = ["marinated cactus leaves", "pico de gallo", "black beans", "lettuce", "maize", "rice"]
