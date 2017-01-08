#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

class obiekt(object):
    def f1(self):
        print("Oryginalna funkcja f1")

    def f2(self):
        print("Oryginalna funkcja f2")


class obiekt_udekorowany(object):
    def __new__(cls, dekorowany):
        cls = type('udekorowany',
                   (obiekt_udekorowany, dekorowany.__class__),
                   dekorowany.__dict__)
        return object.__new__(cls)

    def f1(self):
        print("Udekorowana funkcja f1")
        print("Zrób coś jeszcze przed oryginalnym f1 :)")
        super(obiekt_udekorowany, self).f1()
        print("Albo po oryginalnym f1")

class obiekt_udekorowany2(object):
    def __new__(cls, dekorowany):
        cls = type('udekorowany2',
                   (obiekt_udekorowany2, dekorowany.__class__),
                   dekorowany.__dict__)
        return object.__new__(cls)

    def f1(self):
        print("Jeszcze bardziej udekorowana funkcja.")
        super(obiekt_udekorowany2, self).f1()
        print("Po jeszcze wiekszym udekorowaniu.")

    def f2(self):
        print("F2 z udekorowany 2")
        super(obiekt_udekorowany2, self).f2()


u = obiekt()
v = obiekt_udekorowany(u)
x = obiekt_udekorowany2(v)

print("\n--- v.f1()")
v.f1()
print("\n--- v.f2()")
v.f2()
print("\n--- x.f1()")
x.f1()
print("\n--- x.f2()")
x.f2()


print("\n\n======== Sprawdzenie typów: ========")
print('isinstance(v, obiekt) ==', isinstance(v, obiekt))
print('isinstance(x, obiekt) ==', isinstance(x, obiekt))