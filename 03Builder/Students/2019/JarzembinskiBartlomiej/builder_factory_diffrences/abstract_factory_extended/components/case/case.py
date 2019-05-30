from abc import ABC, abstractmethod


class Case(ABC):

  def __init__(self):
    pass

  @abstractmethod
  def __str__(self):
    pass