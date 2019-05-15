from ingredients_factory.quesadilla_ingredients_factory import QuesadillaIngredientsFactory
from menu.con_carne import ConCarne
from menu.grilled_chicken import GrilledChicken
from menu.pork import Pork
from menu.pulled_chicken import PulledChicken
from menu.vegan import Vegan
from store.food_store import FoodStore


class QuesadillaFoodStore(FoodStore):

  @staticmethod
  def create_food(food_type):
    food = None
    ingredients_factory = QuesadillaIngredientsFactory()

    if food_type == "con_carne":
      food = ConCarne(ingredients_factory)
    elif food_type == "grilled_chicken":
      food = GrilledChicken(ingredients_factory)
    elif food_type == "pork":
      food = Pork(ingredients_factory)
    elif food_type == "pulled_chicken":
      food = PulledChicken(ingredients_factory)
    elif food_type == "vegan":
      food = Vegan(ingredients_factory)
    else:
      food = None
    return food