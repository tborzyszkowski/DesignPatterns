import sys, time

from abc import ABC, abstractmethod


class Food(ABC):

  def __init__(self):
    self._name = None
    self._meat = None
    self._sauce = None
    self._tortilla = None
    self._vegetables = None

  @abstractmethod
  def prepare(self):
    pass

  def print_info(self):
    print("You has chosen {}".format(self._name),
          "\nInfo about your product:",
          "\n- meat: {}".format(self._meat),
          "\n- sauce: {}".format(self._sauce),
          "\n- tortilla: {}".format(self._tortilla),
          "\n- vegetables: {}".format(self._vegetables))