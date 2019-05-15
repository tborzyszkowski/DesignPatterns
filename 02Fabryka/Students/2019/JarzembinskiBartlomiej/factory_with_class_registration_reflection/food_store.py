from menu.food import Food
from threading import Lock


class FoodStore:
  _instances = {}
  _threading_lock = Lock()
  _registered_products =  {}

  def __new__(cls):
    if type(object.__new__(cls)).__name__ not in cls._instances:
      with cls._threading_lock:
        if type(object.__new__(cls)).__name__ not in cls._instances:
          cls._instances[type(object.__new__(cls)).__name__] = object.__new__(cls)
    return cls._instances[type(object.__new__(cls)).__name__]

  @classmethod
  def register_product(cls, food_type, food_class):
    cls._registered_products[food_type] = food_class

  @classmethod
  def order_food(cls, food_type):
    klasa = cls._registered_products[food_type]
    
    food = klasa()
    return food