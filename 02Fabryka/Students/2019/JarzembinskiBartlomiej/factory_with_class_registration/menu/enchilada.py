from abc import abstractmethod
from menu.food import Food


class Enchilada(Food):

  @property
  @classmethod
  @abstractmethod
  def _number_of_tortillas(cls):
    pass

  @classmethod
  def print_info(cls):
    print("You has chosen {}".format(cls._name),
          "\nInfo about your product:",
          "\n- kind of tortilla: {}".format(cls._tortilla),
          "\n- number of tortillas: {}".format(cls._number_of_tortillas),
          "\n- spice: {}".format(cls._spice),
          "\n- components: {}".format(cls._components))