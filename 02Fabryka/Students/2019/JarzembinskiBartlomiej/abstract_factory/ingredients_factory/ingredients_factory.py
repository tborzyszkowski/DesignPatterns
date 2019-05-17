from abc import ABC, abstractmethod


class IngredientsFactory(ABC):

  @abstractmethod
  def get_meat(self):
    pass

  @abstractmethod
  def get_sauce(self):
    pass

  @abstractmethod
  def get_tortilla(self):
    pass

  @abstractmethod
  def get_vegetables(self):
    pass