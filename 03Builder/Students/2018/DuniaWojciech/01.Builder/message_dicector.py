from window_builder_abstract_class import WindowBuilder


class Message:
    def build(self, window_builder: WindowBuilder):
        window_builder.set_type()
        window_builder.set_size()
        window_builder.set_message()
        window_builder.set_button_ok()
        window_builder.set_button_cancel()
