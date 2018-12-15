class Window():
    def __init__(self):
        self._properties = {}

    def getWindow(self):
        i = 1
        for key, value in self._properties.items():
            print('{}. {}: {}'.format(i, key, value))
            i += 1

    def set_property(self, key, value):
        self._properties.update({key: value})