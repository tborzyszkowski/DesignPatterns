from menu.burritos.con_carne import BurritoConCarne
from menu.burritos.grilled_chicken import BurritoGrilledChicken
from menu.burritos.pork import BurritoPork
from menu.burritos.pulled_chicken import BurritoPulledChicken
from menu.burritos.vegan import BurritoVegan
from menu.enchiladas.con_carne import EnchiladaConCarne
from menu.enchiladas.grilled_chicken import EnchiladaGrilledChicken
from menu.enchiladas.pork import EnchiladaPork
from menu.enchiladas.pulled_chicken import EnchiladaPulledChicken
from menu.enchiladas.vegan import EnchiladaVegan
from menu.quesadillas.con_carne import QuesadillaConCarne
from menu.quesadillas.grilled_chicken import QuesadillaGrilledChicken
from menu.quesadillas.pork import QuesadillaPork
from menu.quesadillas.pulled_chicken import QuesadillaPulledChicken
from menu.quesadillas.vegan import QuesadillaVegan
from threading import Lock


class FoodStore:
  _instances = {}
  _threading_lock = Lock()

  def __new__(cls):
    if type(object.__new__(cls)).__name__ not in cls._instances:
      with cls._threading_lock:
        if type(object.__new__(cls)).__name__ not in cls._instances:
          cls._instances[type(object.__new__(cls)).__name__] = object.__new__(cls)
    return cls._instances[type(object.__new__(cls)).__name__]

  @staticmethod
  def order_food(food_type):
    food = None

    if food_type == "burrito_con_carne":
      food = BurritoConCarne()
    elif food_type == "burrito_grilled_chicken":
      food = BurritoGrilledChicken()
    elif food_type == "burrito_pork":
      food = BurritoPork()
    elif food_type == "burrito_pulled_chicken":
      food = BurritoPulledChicken()
    elif food_type == "burrito_vegan":
      food = BurritoVegan()
    elif food_type == "enchilada_con_carne":
      food = EnchiladaConCarne()
    elif food_type == "enchilada_grilled_chicken":
      food = EnchiladaGrilledChicken()
    elif food_type == "enchilada_pork":
      food = EnchiladaPork()
    elif food_type == "enchilada_pulled_chicken":
      food = EnchiladaPulledChicken()
    elif food_type == "enchilada_vegan":
      food = EnchiladaVegan()
    elif food_type == "quesadilla_con_carne":
      food = QuesadillaConCarne()
    elif food_type == "quesadilla_grilled_chicken":
      food = QuesadillaGrilledChicken()
    elif food_type == "quesadilla_pork":
      food = QuesadillaPork()
    elif food_type == "quesadilla_pulled_chicken":
      food = QuesadillaPulledChicken()
    elif food_type == "quesadilla_vegan":
      food = QuesadillaVegan()
    else:
      food = None
    return food