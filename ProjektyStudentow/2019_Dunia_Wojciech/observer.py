# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from abc import ABC, abstractmethod


class Observer(ABC):
    def __init__(self):
        self._state = None

    @abstractmethod
    def do(self, state): pass


class Observable(ABC):
    def __init__(self):
        self.subscribed = []
        self._value = None

    def subscribe(self, observer: Observer):
        self.subscribed.append(observer)

    def unsubscribe(self, observer: Observer):
        self.subscribed.remove(observer)

    def _inform_observers(self):
        for sub in self.subscribed:
            sub.do(self._value)

    @property
    @abstractmethod
    def value(self):
        pass

    @value.setter
    @abstractmethod
    def value(self, *args):
        pass


class EnemiesMovementObservable(Observable):
    @property
    def value(self):
        return self._value

    @value.setter
    def value(self, value):
        self._value = value
        self._inform_observers()
