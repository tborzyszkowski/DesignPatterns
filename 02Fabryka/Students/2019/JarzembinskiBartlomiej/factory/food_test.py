import unittest

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
from food_store import FoodStore


class TestSimpleFactory(unittest.TestCase):

  def test_singleton(self):
    first_singleton = FoodStore()
    second_singleton = FoodStore()
    self.assertTrue(first_singleton is second_singleton)
  
  def test_create_burritos(self):
    store = FoodStore()

    burrito = store.order_food("burrito_con_carne")
    self.assertIsInstance(burrito, BurritoConCarne)

    burrito = store.order_food("burrito_grilled_chicken")
    self.assertIsInstance(burrito, BurritoGrilledChicken)

    burrito = store.order_food("burrito_pork")
    self.assertIsInstance(burrito, BurritoPork)

    burrito = store.order_food("burrito_pulled_chicken")
    self.assertIsInstance(burrito, BurritoPulledChicken)

    burrito = store.order_food("burrito_vegan")
    self.assertIsInstance(burrito, BurritoVegan)

  def test_create_enchiladas(self):
    store = FoodStore()

    enchilada = store.order_food("enchilada_con_carne")
    self.assertIsInstance(enchilada, EnchiladaConCarne)

    enchilada = store.order_food("enchilada_grilled_chicken")
    self.assertIsInstance(enchilada, EnchiladaGrilledChicken)

    enchilada = store.order_food("enchilada_pork")
    self.assertIsInstance(enchilada, EnchiladaPork)

    enchilada = store.order_food("enchilada_pulled_chicken")
    self.assertIsInstance(enchilada, EnchiladaPulledChicken)

    enchilada = store.order_food("enchilada_vegan")
    self.assertIsInstance(enchilada, EnchiladaVegan)

  def test_create_quesadillas(self):
    store = FoodStore()

    quesadilla = store.order_food("quesadilla_con_carne")
    self.assertIsInstance(quesadilla, QuesadillaConCarne)

    quesadilla = store.order_food("quesadilla_grilled_chicken")
    self.assertIsInstance(quesadilla, QuesadillaGrilledChicken)

    quesadilla = store.order_food("quesadilla_pork")
    self.assertIsInstance(quesadilla, QuesadillaPork)

    quesadilla = store.order_food("quesadilla_pulled_chicken")
    self.assertIsInstance(quesadilla, QuesadillaPulledChicken)

    quesadilla = store.order_food("quesadilla_vegan")
    self.assertIsInstance(quesadilla, QuesadillaVegan)

if __name__ == "__main__":
  unittest.main()