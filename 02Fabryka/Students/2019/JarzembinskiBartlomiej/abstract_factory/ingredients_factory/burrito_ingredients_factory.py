from ingredients.meat.beef import Beef
from ingredients.sauce.serrano import Serrano
from ingredients.tortilla.wheat import Wheat
from ingredients.vegetables.lettuce import Lettuce
from ingredients_factory.ingredients_factory import IngredientsFactory


class BurritoIngredientsFactory(IngredientsFactory):

  def get_meat(self):
    return Beef()

  def get_sauce(self):
    return Serrano()

  def get_tortilla(self):
    return Wheat()

  def get_vegetables(self):
    return Lettuce()