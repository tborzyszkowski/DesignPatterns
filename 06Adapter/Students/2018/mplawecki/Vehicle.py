"""
Seabird
Seacraft
Aircraft
"""

class SeaCraft(object):
    def __init__(self, name):
        self.name = name
        self.depth = 0
    def __str__(self):
        return "{}".format(self.name)
    def depth(self):
        print("Getting max depth")
        return self.depth
    def swim(self):
        return "do swimming  "



class AirCraft(object):
    def __init__(self,name):
        self.name = name
        self.speed = 0
    def __str__(self):
        return "{}".format(self.name)

    def speed(self,speed):
        if (speed < 20):
            raise ValueError("Not possible to fly at that speed")
        self.speed = speed
    def fly(self):
        return 'do flying'


class SeaBird(object):
    def __init__(self, obj, adapted_methods):
        self.obj = obj
        self.__dict__.update(adapted_methods)
    def __str__(self):
        return str(self.obj)

def main():
    vehicles = [SeaCraft('neptun')]
    jumbo = AirCraft('falcon')
    vehicles.append(SeaBird(jumbo, dict(swim=jumbo.fly)))
    for i in vehicles:
        print('{} {}'.format(str(i), i.swim()))


if __name__=="__main__":
    main()








