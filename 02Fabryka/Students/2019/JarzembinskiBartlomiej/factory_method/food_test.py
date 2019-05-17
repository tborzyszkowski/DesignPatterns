import unittest

from store.burrito_food_store import BurritoFoodStore
from store.enchilada_food_store import EnchiladaFoodStore
from store.quesadilla_food_store import QuesadillaFoodStore
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


class TestFactoryMethod(unittest.TestCase):

  def test_singleton(self):
    first_singleton = BurritoFoodStore()
    second_singleton = BurritoFoodStore()
    self.assertTrue(first_singleton is second_singleton)
  
  def test_create_burritos(self):
    buritto_store = BurritoFoodStore()

    food = buritto_store.order_food("con_carne")
    self.assertIsInstance(food, BurritoConCarne)

    food = buritto_store.order_food("grilled_chicken")
    self.assertIsInstance(food, BurritoGrilledChicken)

    food = buritto_store.order_food("pork")
    self.assertIsInstance(food, BurritoPork)

    food = buritto_store.order_food("pulled_chicken")
    self.assertIsInstance(food, BurritoPulledChicken)

    food = buritto_store.order_food("vegan")
    self.assertIsInstance(food, BurritoVegan)

  def test_create_enchiladas(self):
    enchilada_store = EnchiladaFoodStore()

    food = enchilada_store.order_food("con_carne")
    self.assertIsInstance(food, EnchiladaConCarne)

    food = enchilada_store.order_food("grilled_chicken")
    self.assertIsInstance(food, EnchiladaGrilledChicken)

    food = enchilada_store.order_food("pork")
    self.assertIsInstance(food, EnchiladaPork)

    food = enchilada_store.order_food("pulled_chicken")
    self.assertIsInstance(food, EnchiladaPulledChicken)

    food = enchilada_store.order_food("vegan")
    self.assertIsInstance(food, EnchiladaVegan)

  def test_create_quesadillas(self):
    quesadilla_store = QuesadillaFoodStore()

    food = quesadilla_store.order_food("con_carne")
    self.assertIsInstance(food, QuesadillaConCarne)

    food = quesadilla_store.order_food("grilled_chicken")
    self.assertIsInstance(food, QuesadillaGrilledChicken)

    food = quesadilla_store.order_food("pork")
    self.assertIsInstance(food, QuesadillaPork)

    food = quesadilla_store.order_food("pulled_chicken")
    self.assertIsInstance(food, QuesadillaPulledChicken)

    food = quesadilla_store.order_food("vegan")
    self.assertIsInstance(food, QuesadillaVegan)

if __name__ == "__main__":
  unittest.main()

buritto_store = BurritoFoodStore()
food1 = buritto_store.order_food("con_carne")
BurritoConCarne._name = "test"
BurritoConCarne.name = "test"
food2 = buritto_store.order_food("con_carne")
food3 = buritto_store.order_food("con_carne")
print(food1._name)
print(food2._name)

print(food2.print_info)