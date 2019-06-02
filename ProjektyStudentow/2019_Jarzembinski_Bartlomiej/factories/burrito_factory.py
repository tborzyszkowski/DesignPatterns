from menu.burritos.con_carne import BurritoConCarne
from menu.burritos.grilled_chicken import BurritoGrilledChicken
from menu.burritos.pork import BurritoPork
from menu.burritos.pulled_chicken import BurritoPulledChicken
from menu.burritos.vegan import BurritoVegan
from factories.dish_factory import DishFactory


class BurritoFactory(DishFactory):
  def create_dish(self, dish_type):
    dish = None

    if dish_type == "con_carne":
      dish = BurritoConCarne(self.discount)
    elif dish_type == "grilled_chicken":
      dish = BurritoGrilledChicken(self.discount)
    elif dish_type == "pork":
      dish = BurritoPork(self.discount)
    elif dish_type == "pulled_chicken":
      dish = BurritoPulledChicken(self.discount)
    elif dish_type == "vegan":
      dish = BurritoVegan(self.discount)
    else:
      dish = None
    return dish
