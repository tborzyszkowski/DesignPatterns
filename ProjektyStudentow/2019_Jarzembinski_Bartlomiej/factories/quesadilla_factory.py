from menu.quesadillas.con_carne import QuesadillaConCarne
from menu.quesadillas.grilled_chicken import QuesadillaGrilledChicken
from menu.quesadillas.pork import QuesadillaPork
from menu.quesadillas.pulled_chicken import QuesadillaPulledChicken
from menu.quesadillas.vegan import QuesadillaVegan
from factories.dish_factory import DishFactory


class QuesadillaFactory(DishFactory):
  def create_dish(self, dish_type):
    dish = None

    if dish_type == "con_carne":
      dish = QuesadillaConCarne(self.discount)
    elif dish_type == "grilled_chicken":
      dish = QuesadillaGrilledChicken(self.discount)
    elif dish_type == "pork":
      dish = QuesadillaPork(self.discount)
    elif dish_type == "pulled_chicken":
      dish = QuesadillaPulledChicken(self.discount)
    elif dish_type == "vegan":
      dish = QuesadillaVegan(self.discount)
    else:
      dish = None
    return dish
