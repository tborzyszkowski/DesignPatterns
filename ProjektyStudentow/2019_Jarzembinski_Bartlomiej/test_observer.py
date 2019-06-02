# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""
import unittest

from unittest.mock import patch
from factories.burrito_factory import BurritoFactory
from waiter import Waiter


class TestObserver(unittest.TestCase):

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_initial_state_of_observer_list(self):
        factory = BurritoFactory(discount = 0)
        order = factory.order_dish()
        self.assertEqual(len(order._observers), 0)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_if_observer_is_attachable_and_detachable(self):
        factory = BurritoFactory(discount = 0)
        order = factory.order_dish()
        waiter = Waiter()
        order.attach(waiter)
        self.assertEqual(isinstance(order._observers[0], Waiter), True)
        self.assertEqual(len(order._observers), 1)
        order.detach(waiter)
        self.assertEqual(len(order._observers), 0)

    @patch("factories.dish_factory.input", lambda *args: "con_carne")
    def test_notification(self):
        factory = BurritoFactory(discount = 0)
        order = factory.order_dish()
        waiter = Waiter()
        order.attach(waiter)
        with patch.object(waiter, "update") as mock_update:
            order.prepare()
            self.assertEqual(mock_update.call_count, 1)


if __name__ == "__main__":
    unittest.main()
