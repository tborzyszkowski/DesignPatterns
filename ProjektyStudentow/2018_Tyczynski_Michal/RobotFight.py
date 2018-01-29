from abc import ABCMeta, abstractmethod
import threading
import random
drivers = ["Mark", "Frank", "John", "Andy", "Bill", "Dexter", "Matthew", "Jared"]

class Builder:
    def getTrack(self): pass
    def getEngine(self): pass
    def getBody(self): pass
    def getTurret(self): pass
    def getGun(self): pass

class EnemyAttacker():
    @abstractmethod
    def fireWeapon(self): pass
    @abstractmethod
    def driveForward(self): pass
    @abstractmethod
    def changeDriver(self, name): pass

def singleton(class_):
    instances = {}
    def getinstance(*args, **kwargs):
        print("Attempting to create a robot...")
        if class_ not in instances:
            instances[class_] = class_(*args, **kwargs)
        else:
            print("THERE CAN BE ONLY ONE ROBOT.. REPAIRING CURRENT ONE!")
        return instances[class_]
    return getinstance

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


class Tank(EnemyAttacker):
    def __init__(self):
        self.gun = None
        self.turret = None
        self.engine = None
        self.body = None
        self.tracks = []
        self.name = None

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

    def fireWeapon(self, name):
        print( "Tank shots for 123 damage!")

    def driveForward(self):
        print("GO! Tank dives Forward!")

    def changeDriver(self, name):
        print("Assigned %s to drive." %(name))
        self.name = name

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

@singleton
class EnemyRobot:
    name = None
    def __init__(self, name="SUPER_ROBOT_V2"):
        self.name = name

    def handsAttack(self, name):
        print("Robot attacked tank with hands for over 9000 dmg.")

    def walk(self):
        print("Robot walks forward.")

    def reactToHuman(self, driver_name):
        print("Robot kills tank driver named " + driver_name)


class EnemyRobotAdapter(EnemyAttacker):
    def __init__(self, robot):
        self.robot = robot

    def fireWeapon(self, name):
        return self.robot.handsAttack(name)

    def driveForward(self):
        return self.robot.walk()

    def changeDriver(self, name):
        return self.robot.reactToHuman(name)

class FightSimulation:
    # Mediator
    def __init__(self, robot, tank):
        self.robotAdapter = EnemyRobotAdapter(robot)
        self.tank = tank

    #Fasada
    def fight(self):
        self.tank.changeDriver(drivers[random.randint(0, 7)])
        self.tank.driveForward()
        self.tank.fireWeapon("Robot")

        # robot with adapter
        self.robotAdapter.changeDriver(self.tank.name)
        self.robotAdapter.driveForward()
        self.robotAdapter.fireWeapon(self.tank.name)

def main():
    director = Director()
    destroyerBuilder = TankDestroyer()
    spgBuilder = ArtilleryBuilder()

    print ("SPG")
    director.setBuilder(spgBuilder)
    spg = director.getTank()
    spg.print_info()
    print("-" *30)

    theRobot = EnemyRobot()
    walka = FightSimulation(tank=spg, robot=theRobot)
    walka.fight()
    print("-" *30)

    print ("TankDestroyer")
    director.setBuilder(destroyerBuilder)
    tank = director.getTank()
    tank.print_info()
    print("-" * 30)

    theRobot = EnemyRobot()
    walka = FightSimulation(tank=tank, robot=theRobot)
    walka.fight()



if __name__ == "__main__":
    main()