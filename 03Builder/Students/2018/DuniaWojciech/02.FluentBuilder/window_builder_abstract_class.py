from abc import ABC, abstractmethod
from window_class import Window

class WindowBuilder(ABC):

    def __init__(self):
        self.window = Window()
        self.method = None

    def __call__(self):
        if self.method:
            return self.method
        return None

    def show(self):
        return self.window

    @abstractmethod
    def build_window(self):
        pass

    @abstractmethod
    def set_size(self):
        pass

    @abstractmethod
    def set_type(self):
        pass

    @abstractmethod
    def set_message(self):
        pass

    @abstractmethod
    def set_button_ok(self):
        pass

    @abstractmethod
    def set_button_cancel(self):
        pass

    @abstractmethod
    def set_button_ok(self):
        pass


