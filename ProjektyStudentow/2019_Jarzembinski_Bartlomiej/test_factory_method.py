import unittest

from factories.burrito_factory import BurritoFactory
from factories.enchilada_factory import EnchiladaFactory
from factories.quesadilla_factory import QuesadillaFactory
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
from unittest.mock import patch


class TestFactoryMethod(unittest.TestCase):
    discount = 0
    
    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_ordering_burrito_con_carne(self):
        burrito_factory = BurritoFactory(self.discount)
        burrito = burrito_factory.order_dish()
        self.assertIsInstance(burrito.dish, BurritoConCarne)

    @patch("factories.dish_factory.input", lambda *args: "grilled_chicken")
    def test_ordering_grilled_chicken_burrito(self):
        burrito_factory = BurritoFactory(self.discount)
        burrito = burrito_factory.order_dish()
        self.assertIsInstance(burrito.dish, BurritoGrilledChicken)

    @patch("factories.dish_factory.input", lambda *args: "pork")
    def test_ordering_pork_burrito(self):
        burrito_factory = BurritoFactory(self.discount)
        burrito = burrito_factory.order_dish()
        self.assertIsInstance(burrito.dish, BurritoPork)

    @patch("factories.dish_factory.input", lambda *args: "pulled_chicken")
    def test_ordering_pulled_chicken_burrito(self):
        burrito_factory = BurritoFactory(self.discount)
        burrito = burrito_factory.order_dish()
        self.assertIsInstance(burrito.dish, BurritoPulledChicken)

    @patch("factories.dish_factory.input", lambda *args: "vegan")
    def test_ordering_vegan_burrito(self):
        burrito_factory = BurritoFactory(self.discount)
        burrito = burrito_factory.order_dish()
        self.assertIsInstance(burrito.dish, BurritoVegan)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_ordering_enchilada_con_carne(self):
        enchilada_factory = EnchiladaFactory(self.discount)
        enchilada = enchilada_factory.order_dish()
        self.assertIsInstance(enchilada.dish, EnchiladaConCarne)

    @patch("factories.dish_factory.input", lambda *args: "grilled_chicken")
    def test_ordering_grilled_chicken_enchilada(self):
        enchilada_factory = EnchiladaFactory(self.discount)
        enchilada = enchilada_factory.order_dish()
        self.assertIsInstance(enchilada.dish, EnchiladaGrilledChicken)

    @patch("factories.dish_factory.input", lambda *args: "pork")
    def test_ordering_pork_enchilada(self):
        enchilada_factory = EnchiladaFactory(self.discount)
        enchilada = enchilada_factory.order_dish()
        self.assertIsInstance(enchilada.dish, EnchiladaPork)

    @patch("factories.dish_factory.input", lambda *args: "pulled_chicken")
    def test_ordering_pulled_chicken_enchilada(self):
        enchilada_factory = EnchiladaFactory(self.discount)
        enchilada = enchilada_factory.order_dish()
        self.assertIsInstance(enchilada.dish, EnchiladaPulledChicken)

    @patch("factories.dish_factory.input", lambda *args: "vegan")
    def test_ordering_vegan_enchilada(self):
        enchilada_factory = EnchiladaFactory(self.discount)
        enchilada = enchilada_factory.order_dish()
        self.assertIsInstance(enchilada.dish, EnchiladaVegan)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_ordering_quesadilla_con_carne(self):
        quesadilla_factory = QuesadillaFactory(self.discount)
        quesadilla = quesadilla_factory.order_dish()
        self.assertIsInstance(quesadilla.dish, QuesadillaConCarne)

    @patch("factories.dish_factory.input", lambda *args: "grilled_chicken")
    def test_ordering_grilled_chicken_quesadilla(self):
        quesadilla_factory = QuesadillaFactory(self.discount)
        quesadilla = quesadilla_factory.order_dish()
        self.assertIsInstance(quesadilla.dish, QuesadillaGrilledChicken)

    @patch("factories.dish_factory.input", lambda *args: "pork")
    def test_ordering_pork_quesadilla(self):
        quesadilla_factory = QuesadillaFactory(self.discount)
        quesadilla = quesadilla_factory.order_dish()
        self.assertIsInstance(quesadilla.dish, QuesadillaPork)

    @patch("factories.dish_factory.input", lambda *args: "pulled_chicken")
    def test_ordering_pulled_chicken_quesadilla(self):
        quesadilla_factory = QuesadillaFactory(self.discount)
        quesadilla = quesadilla_factory.order_dish()
        self.assertIsInstance(quesadilla.dish, QuesadillaPulledChicken)

    @patch("factories.dish_factory.input", lambda *args: "vegan")
    def test_ordering_vegan_quesadilla(self):
        quesadilla_factory = QuesadillaFactory(self.discount)
        quesadilla = quesadilla_factory.order_dish()
        self.assertIsInstance(quesadilla.dish, QuesadillaVegan)


if __name__ == "__main__":
    unittest.main()
