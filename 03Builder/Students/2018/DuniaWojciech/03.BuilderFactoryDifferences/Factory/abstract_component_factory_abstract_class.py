from abc import ABC, abstractmethod
from typing import List
import threading

class ComponentAbstractFactory(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    @abstractmethod
    def create_button_cancel(self):
        pass

    @abstractmethod
    def create_button_ok(self):
        pass

    @abstractmethod
    def create_combobox(self):
        pass

    @abstractmethod
    def create_text(self):
        pass

    @abstractmethod
    def create_menu(self):
        pass
