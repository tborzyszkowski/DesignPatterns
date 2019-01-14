from window_builder_abstract_class import WindowBuilder


class Message:
    def build(self, window_builder: WindowBuilder):
        return window_builder\
            .set_type()\
            .set_size()\
            .set_message()\
            .set_button_ok()\
            .set_button_cancel()()
