from ingredients.meat.pulled_chicken import PulledChicken
from ingredients.sauce.jalapeno import Jalapeno
from ingredients.tortilla.wheat import Wheat
from ingredients.vegetables.beans import Beans
from ingredients_factory.ingredients_factory import IngredientsFactory


class EnchiladaIngredientsFactory(IngredientsFactory):

  def get_meat(self):
    return PulledChicken()

  def get_sauce(self):
    return Jalapeno()

  def get_tortilla(self):
    return Wheat()

  def get_vegetables(self):
    return Beans()