from abc import ABC, abstractmethod


class Ram(ABC):

  def __init__(self):
    pass

  @abstractmethod
  def __str__(self):
    pass