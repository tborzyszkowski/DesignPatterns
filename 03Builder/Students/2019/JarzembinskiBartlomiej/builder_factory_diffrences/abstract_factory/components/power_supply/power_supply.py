from abc import ABC, abstractmethod


class PowerSupply(ABC):

  def __init__(self):
    pass

  @abstractmethod
  def __str__(self):
    pass