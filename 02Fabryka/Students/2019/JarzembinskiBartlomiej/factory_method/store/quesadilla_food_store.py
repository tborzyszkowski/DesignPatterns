from menu.quesadillas.con_carne import QuesadillaConCarne
from menu.quesadillas.grilled_chicken import QuesadillaGrilledChicken
from menu.quesadillas.pork import QuesadillaPork
from menu.quesadillas.pulled_chicken import QuesadillaPulledChicken
from menu.quesadillas.vegan import QuesadillaVegan
from store.food_store import FoodStore


class QuesadillaFoodStore(FoodStore):
  @staticmethod
  def create_food(food_type):
    food = None

    if food_type == "con_carne":
      food = QuesadillaConCarne()
    elif food_type == "grilled_chicken":
      food = QuesadillaGrilledChicken()
    elif food_type == "pork":
      food = QuesadillaPork()
    elif food_type == "pulled_chicken":
      food = QuesadillaPulledChicken()
    elif food_type == "vegan":
      food = QuesadillaVegan()
    else:
      food = None
    return food