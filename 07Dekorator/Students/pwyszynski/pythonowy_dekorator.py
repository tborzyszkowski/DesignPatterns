#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"


def paragraf_deko(func):
    def func_wrapper(name):
        return "<p>{0}</p>".format(func(name))

    return func_wrapper


@paragraf_deko
def get_text(name):
    return "Tekst w paragrafie: {0}".format(name)

print(get_text("Przemek"))