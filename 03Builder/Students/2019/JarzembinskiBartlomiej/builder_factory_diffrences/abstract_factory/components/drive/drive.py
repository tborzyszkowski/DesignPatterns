from abc import ABC, abstractmethod


class Drive(ABC):

  def __init__(self):
    pass

  @abstractmethod
  def __str__(self):
    pass