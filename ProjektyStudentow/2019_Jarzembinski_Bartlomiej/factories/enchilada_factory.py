from menu.enchiladas.con_carne import EnchiladaConCarne
from menu.enchiladas.grilled_chicken import EnchiladaGrilledChicken
from menu.enchiladas.pork import EnchiladaPork
from menu.enchiladas.pulled_chicken import EnchiladaPulledChicken
from menu.enchiladas.vegan import EnchiladaVegan
from factories.dish_factory import DishFactory


class EnchiladaFactory(DishFactory):
  def create_dish(self, dish_type):
    dish = None

    if dish_type == "con_carne":
      dish = EnchiladaConCarne(self.discount)
    elif dish_type == "grilled_chicken":
      dish = EnchiladaGrilledChicken(self.discount)
    elif dish_type == "pork":
      dish = EnchiladaPork(self.discount)
    elif dish_type == "pulled_chicken":
      dish = EnchiladaPulledChicken(self.discount)
    elif dish_type == "vegan":
      dish = EnchiladaVegan(self.discount)
    else:
      dish = None
    return dish
