from typing import List

from abstract_component_factory_abstract_class import ComponentAbstractFactory


class ComponentFactory2(ComponentAbstractFactory):
    def create_button_cancel(self):
        return Button()

    def create_button_ok(self):
        return Button()

    def create_combobox(self):
        return Combo()

    def create_text(self):
        return Text()

    def create_menu(self):
        return Menu()


class Button:
    pass

class Combo:
    pass

class Text:
    pass

class Menu:
    pass