#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

import copy
import re

class SamplePrototype(object):
    def __init__(self, integer, simple_list, complex_list, obj):
        self._number = integer
        self._s_list = simple_list
        self._c_list = complex_list
        self._obj = obj

    #region Gettery i settery
    @property
    def obj(self):
        return self._obj

    @property
    def number(self):
        return self._number

    @property
    def c_list(self):
        return self._c_list

    @property
    def s_list(self):
        return self._s_list

    @obj.setter
    def obj(self, value):
        self._obj = value

    @number.setter
    def number(self, value):
        self._number = value

    @c_list.setter
    def c_list(self, value):
        self._c_list = value

    @s_list.setter
    def s_list(self, value):
        self._s_list = value

    #endregion

    def clone(self, new_int = None, new_s_list = None, new_c_list = None, new_obj = None):
        x = copy.deepcopy(self)

        if not new_int is None:
            x.number = new_int

        if not new_obj is None:
            x.obj = new_obj

        if not new_s_list is None:
            x.s_list = new_s_list

        if not new_c_list is None:
            x.c_list = new_c_list

        return x

    def pretty_print(self, name):
        print("\n------- {}".format(name))
        print(self.number)
        print(self.obj)
        print(self.s_list)
        print(self.c_list)

if __name__ == "__main__":
    print("\n------ Creating prototype 1. ------")
    prototype1 = SamplePrototype(3,
                                 [3, "strings", object()],
                                 [4, ["more", "strings"], ["list", ["with", [object(), object()]]]],
                                 object())
    prototype1.pretty_print("PROTOTYPE 1")

    print("\n------ Cloning prototype1 into prototype2 without any changes ------")
    prototype2 = prototype1.clone()
    prototype2.pretty_print("PROTOTYPE 2")

    print("\n------ Cloning prototype2 into prototype3 with some changes ------")
    prototype3 = prototype2.clone(5, None, [0, 9, 8, [7, 6, 5, [4, 3, 2, 1]]], re.compile(r"(.*)"))
    prototype3.pretty_print("PROTOTYPE 3")

    # Print proto1 and proto2 to see if it has changed anyhow after cloning into proto3:
    prototype1.pretty_print("PROTOTYPE 1")
    prototype2.pretty_print("PROTOTYPE 2")