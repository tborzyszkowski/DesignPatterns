# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""
import unittest

from menu.burritos.vegan import BurritoVegan
from mexican_restaurant_facade import MexicanRestaurant
from unittest.mock import patch
       

class TestFacade(unittest.TestCase):
        
    @patch("store_proxy.input", lambda *args: "14:55")
    @patch("store.input", lambda *args: "burrito")
    @patch("factories.dish_factory.input", lambda *args: "vegan")
    def test_facade(self):
        restaurant = MexicanRestaurant()
        restaurant.order_dish()
        self.assertIsInstance(restaurant.store.orders_list[-1].dish, BurritoVegan)


if __name__ == "__main__":
    unittest.main()
