class Computer():
    def __init__(self, type):
        self._type = type
        self._properties = {}

    def show(self):
        print(f"ID: {id(self)}")
        print(f"Type: {self._type}")
        for key, value in self._properties.items():
            print(f"- {key}: {value}")
