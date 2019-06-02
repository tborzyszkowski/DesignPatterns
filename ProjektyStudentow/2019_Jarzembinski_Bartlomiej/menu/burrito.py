from menu.dish import Dish


class Burrito(Dish):

  def __init__(self):
    self._rice : str

  def print_info(self):
    print(f"Price: {self._price:.4}zł",
          f"\nDish type: {self._name}",
          f"\n- tortilla: {self._tortilla}",
          f"\n- rice: {self._rice}",
          f"\n- spice: {self._spice}",
          f"\n- components: {self._components}")
