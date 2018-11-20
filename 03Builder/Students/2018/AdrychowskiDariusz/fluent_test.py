# Director
class Director(object):
    def __init__(self):
        self.builder = None

    def construct_building(self):
        self.builder.new_building()
        self.builder.build_floor()
        self.builder.build_size()

    def get_building(self):
        return self.builder.building


# Abstract Builder
class Builder(object):
    def __init__(self):
        self.building = None
        self.floor = None
        self.size = None

    def new_building(self):
        self.building = Building()


# Product
class Building(object):
    def __init__(self, builder):
        self.building = builder
        self.floor = builder.floor
        self.size = builder.size

    def __repr__(self):
        return 'Floor: %s | Size: %s' % (self.floor, self.size)

    # Concrete Builder
    class BuilderHouse:
        def __init__(self):
            self.floor = None
            self.size = None

        def build_floor(self):
            self.floor = 'One'
            return self

        def build_size(self):
            self.size = 'Big'
            return self

        def build(self):
            return Building(self)

#Client
if __name__=="__main__":
    '''    
    director = Director()
    director.builder = BuilderHouse()
    director.construct_building()
    building = director.get_building()
    print(building)
    '''
    #start = Building().
    produkt = Building.BuilderHouse().build_floor().build_size().build()

    print(produkt)
