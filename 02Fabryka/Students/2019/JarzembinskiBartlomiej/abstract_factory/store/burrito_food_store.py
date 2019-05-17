from ingredients_factory.burrito_ingredients_factory import BurritoIngredientsFactory
from menu.con_carne import ConCarne
from menu.grilled_chicken import GrilledChicken
from menu.pork import Pork
from menu.pulled_chicken import PulledChicken
from menu.vegan import Vegan
from store.food_store import FoodStore


class BurritoFoodStore(FoodStore):

  @staticmethod
  def create_food(food_type):
    food = None
    ingredients_factory = BurritoIngredientsFactory()

    if food_type == "con_carne":
      food = ConCarne(ingredients_factory)
      food._name = "Buritto con carne"
    elif food_type == "grilled_chicken":
      food = GrilledChicken(ingredients_factory)
      food._name = "Buritto with grilled chicken"
    elif food_type == "pork":
      food = Pork(ingredients_factory)
      food._name = "Buritto with pork"
    elif food_type == "pulled_chicken":
      food = PulledChicken(ingredients_factory)
      food._name = "Buritto with pulled chicken"
    elif food_type == "vegan":
      food = Vegan(ingredients_factory)
      food._name = "Vegan burrito"
    else:
      food = None
    return food