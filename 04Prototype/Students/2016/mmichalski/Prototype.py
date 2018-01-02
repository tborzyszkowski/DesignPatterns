import copy

class Prototype:
    _name = None
    _rgb = None

    def clone(self):
        pass

    def getName(self):
        return self._name

    def getRgbValue(self):
        return self._rgb

class ColorRed(Prototype):
    def __init__(self, rgb):
        self._name = "Red"
        self._rgb = rgb

    def clone(self):
        return copy.copy(self)


class ColorBlue(Prototype):
    def __init__(self, rgb):
        self._name = "Blue"
        self._rgb = rgb

    def clone(self):
        return copy.deepcopy(self)


class ColorFactory:
    __color1 = None
    __color2 = None
    __color3 = None
    __color4 = None

    @staticmethod
    def initialize():
        ColorFactory.__color1 = ColorRed([255,0,0])
        ColorFactory.__color2 = ColorRed([250,0,0])
        ColorFactory.__color3 = ColorBlue([0,0,255])
        ColorFactory.__color4 = ColorBlue([0,0,250])

    @staticmethod
    def getColor1():
        return ColorFactory.__color1.clone()

    @staticmethod
    def getColor2():
        return ColorFactory.__color2.clone()

    @staticmethod
    def getColor3():
        return ColorFactory.__color3.clone()

    @staticmethod
    def getColor4():
        return ColorFactory.__color4.clone()


def main():
    ColorFactory.initialize()

    instance = ColorFactory.getColor1()
    print("%s: %s" % (instance.getName(), instance.getRgbValue()))
    print(instance)

    instance = ColorFactory.getColor2()
    print("%s: %s" % (instance.getName(), instance.getRgbValue()))
    print(instance)

    instance = ColorFactory.getColor3()
    print("%s: %s" % (instance.getName(), instance.getRgbValue()))
    print(instance)

    instance = ColorFactory.getColor4()
    print("%s: %s" % (instance.getName(), instance.getRgbValue()))
    print(instance)


if __name__ == "__main__":
    main()