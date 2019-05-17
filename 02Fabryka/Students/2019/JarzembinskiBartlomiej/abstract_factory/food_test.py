import unittest

from store.burrito_food_store import BurritoFoodStore
from store.enchilada_food_store import EnchiladaFoodStore
from store.quesadilla_food_store import QuesadillaFoodStore
from menu.con_carne import ConCarne
from menu.grilled_chicken import GrilledChicken
from menu.pork import Pork
from menu.pulled_chicken import PulledChicken
from menu.vegan import Vegan


class TestAbstractFactory(unittest.TestCase):

  def test_singleton(self):
    first_singleton = BurritoFoodStore()
    second_singleton = BurritoFoodStore()
    self.assertTrue(first_singleton is second_singleton)
  
  def test_create_burritos(self):
    buritto_store = BurritoFoodStore()

    food = buritto_store.order_food("con_carne")
    self.assertIsInstance(food, ConCarne)

    food = buritto_store.order_food("grilled_chicken")
    self.assertIsInstance(food, GrilledChicken)

    food = buritto_store.order_food("pork")
    self.assertIsInstance(food, Pork)

    food = buritto_store.order_food("pulled_chicken")
    self.assertIsInstance(food, PulledChicken)

    food = buritto_store.order_food("vegan")
    self.assertIsInstance(food, Vegan)

  def test_create_enchiladas(self):
    enchilada_store = EnchiladaFoodStore()

    food = enchilada_store.order_food("con_carne")
    self.assertIsInstance(food, ConCarne)

    food = enchilada_store.order_food("grilled_chicken")
    self.assertIsInstance(food, GrilledChicken)

    food = enchilada_store.order_food("pork")
    self.assertIsInstance(food, Pork)

    food = enchilada_store.order_food("pulled_chicken")
    self.assertIsInstance(food, PulledChicken)

    food = enchilada_store.order_food("vegan")
    self.assertIsInstance(food, Vegan)

  def test_create_quesadillas(self):
    quesadilla_store = QuesadillaFoodStore()

    food = quesadilla_store.order_food("con_carne")
    self.assertIsInstance(food, ConCarne)

    food = quesadilla_store.order_food("grilled_chicken")
    self.assertIsInstance(food, GrilledChicken)

    food = quesadilla_store.order_food("pork")
    self.assertIsInstance(food, Pork)

    food = quesadilla_store.order_food("pulled_chicken")
    self.assertIsInstance(food, PulledChicken)

    food = quesadilla_store.order_food("vegan")
    self.assertIsInstance(food, Vegan)

if __name__ == "__main__":
  unittest.main()