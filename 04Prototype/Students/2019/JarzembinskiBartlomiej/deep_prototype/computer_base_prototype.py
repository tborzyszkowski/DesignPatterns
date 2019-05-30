import copy

class BasePrototype:
    def clone(self):
        return copy.copy(self)

    def deep_clone(self):
        return copy.deepcopy(self)