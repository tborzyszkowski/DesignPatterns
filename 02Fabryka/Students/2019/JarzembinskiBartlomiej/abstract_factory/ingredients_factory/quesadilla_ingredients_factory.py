from ingredients.meat.grilled_chicken import GrilledChicken
from ingredients.sauce.poblano import Poblano
from ingredients.tortilla.wholewheat import WholeWheat
from ingredients.vegetables.corn import Corn
from ingredients_factory.ingredients_factory import IngredientsFactory


class QuesadillaIngredientsFactory(IngredientsFactory):

  def get_meat(self):
    return GrilledChicken()

  def get_sauce(self):
    return Poblano()

  def get_tortilla(self):
    return WholeWheat()

  def get_vegetables(self):
    return Corn()