from menu.burritos.con_carne import BurritoConCarne
from menu.burritos.grilled_chicken import BurritoGrilledChicken
from menu.burritos.pork import BurritoPork
from menu.burritos.pulled_chicken import BurritoPulledChicken
from menu.burritos.vegan import BurritoVegan
from store.food_store import FoodStore


class BurritoFoodStore(FoodStore):
  @staticmethod
  def create_food(food_type):
    food = None

    if food_type == "con_carne":
      food = BurritoConCarne()
    elif food_type == "grilled_chicken":
      food = BurritoGrilledChicken()
    elif food_type == "pork":
      food = BurritoPork()
    elif food_type == "pulled_chicken":
      food = BurritoPulledChicken()
    elif food_type == "vegan":
      food = BurritoVegan()
    else:
      food = None
    return food