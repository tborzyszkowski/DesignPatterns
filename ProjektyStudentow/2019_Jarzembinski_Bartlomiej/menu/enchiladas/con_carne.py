from menu.enchilada import Enchilada


class EnchiladaConCarne(Enchilada):

  def __init__(self, discount):
    self._name = "Enchilada con carne"
    self._price = 18.55 * (1 - discount)
    self._tortilla = "wholewheat"
    self._number_of_tortillas = 4
    self._spice = "hot"
    self._components = ["chili con carne", "coriander", "cheddar", "lettuce", "pico de gallo", "corn", "rice" ]
