from menu.enchiladas.con_carne import EnchiladaConCarne
from menu.enchiladas.grilled_chicken import EnchiladaGrilledChicken
from menu.enchiladas.pork import EnchiladaPork
from menu.enchiladas.pulled_chicken import EnchiladaPulledChicken
from menu.enchiladas.vegan import EnchiladaVegan
from store.food_store import FoodStore


class EnchiladaFoodStore(FoodStore):
  @staticmethod
  def create_food(food_type):
    food = None

    if food_type == "con_carne":
      food = EnchiladaConCarne()
    elif food_type == "grilled_chicken":
      food = EnchiladaGrilledChicken()
    elif food_type == "pork":
      food = EnchiladaPork()
    elif food_type == "pulled_chicken":
      food = EnchiladaPulledChicken()
    elif food_type == "vegan":
      food = EnchiladaVegan()
    else:
      food = None
    return food