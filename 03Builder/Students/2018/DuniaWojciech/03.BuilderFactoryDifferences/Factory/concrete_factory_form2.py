from abstract_form_factory_abstract_class import FormAbstractFactory


class FormFactory2(FormAbstractFactory):
    def create_form(self):
        self.factory_button_ok = self.component_factory.create_button_ok()
        self.factory_button_cancel = self.component_factory.create_button_cancel()
        self.factory_text = None
        self.factory_combobox = self.component_factory.create_combobox()
        self.factory_menu = None


