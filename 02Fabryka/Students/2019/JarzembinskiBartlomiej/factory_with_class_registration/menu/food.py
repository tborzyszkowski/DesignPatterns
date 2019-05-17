from abc import ABC, abstractmethod


class Food(ABC):

  @abstractmethod
  def order_food(self):
    pass

  @property
  @classmethod
  @abstractmethod
  def _name(cls):
    pass
  
  @property
  @classmethod
  @abstractmethod
  def _tortilla(cls):
    pass

  @property
  @classmethod
  @abstractmethod
  def _spice(cls):
    pass
  
  @property
  @classmethod
  @abstractmethod
  def _components(cls):
    pass

  @classmethod
  @abstractmethod
  def print_info(cls):
    pass