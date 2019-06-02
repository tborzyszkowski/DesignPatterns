# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""
import unittest

from menu.burritos.con_carne import BurritoConCarne
from store import Store
from store import Monday
from store import Tuesday
from store import Wednesday
from store import Thursday
from store import Friday
from store import Saturday
from store import Sunday
from unittest.mock import patch


class TestState(unittest.TestCase):

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_monday_burrito_con_carne_price(self):
        store = Store()
        store.state = Monday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Monday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_tuesday_burrito_con_carne_price(self):
        store = Store()
        store.state = Tuesday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Tuesday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_wednesday_burrito_con_carne_price(self):
        store = Store()
        store.state = Wednesday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Wednesday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_thursday_burrito_con_carne_price(self):
        store = Store()
        store.state = Thursday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Thursday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_friday_burrito_con_carne_price(self):
        store = Store()
        store.state = Friday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Friday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_saturday_burrito_con_carne_price(self):
        store = Store()
        store.state = Saturday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Saturday.burrito_discount)._price)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_sunday_burrito_con_carne_price(self):
        store = Store()
        store.state = Sunday()
        factory = store.create_factory("burrito")
        order = factory.order_dish()
        self.assertEqual(order.dish._price, BurritoConCarne(Sunday.burrito_discount)._price)


if __name__ == "__main__":
    unittest.main()
