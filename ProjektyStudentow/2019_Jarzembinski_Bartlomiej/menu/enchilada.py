from menu.dish import Dish


class Enchilada(Dish):

  def __init__(self):
    self._number_of_tortillas : int

  def print_info(self):
    print(f"Price: {self._price:.4}zł",
          f"\nDish type: {self._name}",
          f"\n- kind of tortilla: {self._tortilla}",
          f"\n- number of tortillas: {self._number_of_tortillas}",
          f"\n- spice: {self._spice}",
          f"\n- components: {self._components}")
