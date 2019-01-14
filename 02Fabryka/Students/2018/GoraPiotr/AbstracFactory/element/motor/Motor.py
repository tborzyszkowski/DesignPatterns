from abc import ABC, abstractmethod


class Motor(ABC):

    def __init__(self):
        pass

    @abstractmethod
    def get_motor(self)->str:
        pass
