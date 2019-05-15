from abc import abstractmethod
from menu.food import Food


class Burrito(Food):

  @property
  @classmethod
  @abstractmethod
  def _rice(cls):
    pass

  @classmethod
  def print_info(cls):
    print("You has chosen {}".format(cls._name),
          "\nInfo about your product:",
          "\n- tortilla: {}".format(cls._tortilla),
          "\n- rice: {}".format(cls._rice),
          "\n- spice: {}".format(cls._spice),
          "\n- components: {}".format(cls._components))