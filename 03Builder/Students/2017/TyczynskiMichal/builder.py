class Builder:
    def getTrack(self): pass
    def getEngine(self): pass
    def getBody(self): pass
    def getTurret(self): pass
    def getGun(self): pass

class Director:
    __builder = None

    def setBuilder(self, builder):
        self.__builder = builder

    def getTank(self):
        tank = Tank()

        body = self.__builder.getBody()
        tank.setBody(body)

        turret = self.__builder.getTurret()
        tank.setTurret(turret)

        gun = self.__builder.getGun()
        tank.setGun(gun)

        engine = self.__builder.getEngine()
        tank.setEngine(engine)

        leftTrack = self.__builder.getTrack()
        rightTrack = self.__builder.getTrack()
        tank.setTracks(leftTrack)
        tank.setTracks(rightTrack)

        return tank


class Tank:
    def __init__(self):
        self.gun = None
        self.turret = None
        self.engine = None
        self.body = None
        self.tracks = []

    def setGun(self, gun):
        self.gun = gun

    def setTurret(self, turret):
        self.turret = turret

    def setBody(self, body):
        self.body = body

    def setTracks(self, track):
        self.tracks.append(track)

    def setEngine(self, engine):
        self.engine = engine

    def print_info(self):
        print ("body: %s" % self.body.type)
        print ("engine horsepower: %d" % self.engine.horsepower)
        print ("tracks width: %d cm" % self.tracks[0].width)
        print ("turret type %s" % self.turret.type)
        print ("gun calibers %d" % self.gun.calibers)

class TankDestroyer(Builder):
    def getTrack(self):
        tracks = Track()
        tracks.width = 50
        return tracks

    def getEngine(self):
        engine = Engine()
        engine.horsepower = 1500
        return engine

    def getBody(self):
        body = Body()
        body.type = "Tank Destroyer"
        return body

    def getTurret(self):
        turret = Turret()
        turret.type = "immovable"
        return turret

    def getGun(self):
        gun = Gun()
        gun.calibers = 105
        return gun

class ArtilleryBuilder(Builder):
    def getTrack(self):
        tracks = Track()
        tracks.width = 44
        return tracks

    def getEngine(self):
        engine = Engine()
        engine.horsepower = 1000
        return engine

    def getBody(self):
        body = Body()
        body.type = "SPG"
        return body

    def getTurret(self):
        turret = Turret()
        turret.type = "180 degrees"
        return turret
        
    def getGun(self):
        gun = Gun()
        gun.calibers = 240
        return gun


class Track:
    width = None


class Engine:
    horsepower = None


class Body:
    type = None

class Turret:
    type = None

class Gun:
    calibers = None


def main():
    director = Director()
    destroyerBuilder = TankDestroyer()
    spgBuilder = ArtilleryBuilder()
    

    director.setBuilder(destroyerBuilder)
    td = director.getTank()
    td.print_info()

    print("-" * 30)

    print ("SPG")
    director.setBuilder(spgBuilder)
    spg = director.getTank()
    spg.print_info()


if __name__ == "__main__":
    main()