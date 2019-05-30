class ComputerManager:
    def __init__(self):
        self._registry = {}

    def get_computer(self, name):
        return self._registry[name]

    def set_computer(self, name, computer):
        self._registry.update({name: computer})
