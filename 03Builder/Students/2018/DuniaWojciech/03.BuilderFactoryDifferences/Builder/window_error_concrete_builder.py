from window_builder_abstract_class import WindowBuilder


class WindowError(WindowBuilder):
    def build_window(self):
        self.method = self.show()
        return self

    def set_size(self):
        self.window.set_property('size', "300x100")
        self.method = self.show()
        return self

    def set_type(self):
        self.window.set_property('type', "Error")
        self.method = self.show()
        return self

    def set_message(self):
        self.window.set_property('message', "Runtime error")
        self.method = self.show()
        return self

    def set_button_ok(self):
        self.window.set_property('OK', "True")
        self.method = self.show()
        return self

    def set_button_cancel(self):
        self.window.set_property('CANCEL', "False")
        self.method = self.show()
        return self
