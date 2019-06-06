from menu.dish import Dish


class Quesadilla(Dish):

  def __init__(self):
    self._cheese : str

  def print_info(self):
    print(f"Price: {self._price:.4}zł",
          f"\nDish type: {self._name}",
          f"\n- tortilla: {self._tortilla}",
          f"\n- cheese: {self._cheese}",
          f"\n- spice: {self._spice}",
          f"\n- components: {self._components}")
