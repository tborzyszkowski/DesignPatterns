from abc import ABC, abstractmethod
from abstract_component_factory_abstract_class import ComponentAbstractFactory
import threading

class FormAbstractFactory(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls, fabryka_czesci: ComponentAbstractFactory):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def __init__(self, component_factory: ComponentAbstractFactory):
        self.component_factory = component_factory
        self.factory_button_ok = None
        self.factory_button_cancel = None
        self.factory_text = None
        self.factory_combobox = None
        self.factory_menu = None

    @abstractmethod
    def create_form(self):
        pass
        '''
        self.factory_button_ok
        self.factory_button_cancel
        self.factory_text
        self.factory_combobox
        self.factory_menu
        '''

    # Po wytworzeniu wyswietla specyfikacje
    def show(self):
        print(self)

