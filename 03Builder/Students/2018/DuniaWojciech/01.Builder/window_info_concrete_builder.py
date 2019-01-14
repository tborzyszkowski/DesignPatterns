from window_builder_abstract_class import WindowBuilder


class WindowInfo(WindowBuilder):
    def build_window(self):
        pass

    def set_size(self):
        self.window.set_property('size', "300x100")

    def set_type(self):
        self.window.set_property('type', "Error")

    def set_message(self):
        self.window.set_property('message', "Runtime error")

    def set_button_ok(self):
        self.window.set_property('OK', "True")

    def set_button_cancel(self):
        self.window.set_property('CANCEL', "False")
