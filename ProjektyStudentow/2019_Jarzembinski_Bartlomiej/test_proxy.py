# -*- coding: utf-8 -*-
"""
Created on Wed Apr 22 22:42:51 2019

@author: Bartlomiej Jarzembinski
"""
import unittest

from store import Store
from store_proxy import StoreProxy
from unittest.mock import patch
       

class TestProxy(unittest.TestCase):
        
    @patch("store_proxy.input", lambda *args: "14:55")
    def test_opening_hours(self):
        proxy = StoreProxy()
        store = proxy.create_store()
        self.assertIsInstance(proxy, StoreProxy)
        self.assertIsInstance(store, Store)

    @patch("store_proxy.input", lambda *args: "4:55")
    def test_closing_hours(self):
        proxy = StoreProxy()
        store = proxy.create_store()
        self.assertIsInstance(proxy, StoreProxy)
        self.assertIsNone(store)


if __name__ == "__main__":
    unittest.main()
