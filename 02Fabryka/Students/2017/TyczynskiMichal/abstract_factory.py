# base classes
class Car:
	def name(self):
		pass

class MyCar:
	def race(self, car):
		pass

class CreateRace:
	def createMyCar(self):
		pass

	def createEnemyCar(self):
		pass

# cars
class BMWM3(MyCar):
    def race(self, car):
        print("My BMW races with")
        car.name()

class MercedesAMG(MyCar):
    def race(self, car):
        print("My Mercedes races with")
        car.name()

class VWGolf(Car):
    def name(self): print("GULF")

class AudiA6(Car):
    def name(self): print("Audi")

# factories
class BmwVsAudi(CreateRace):
	def createMyCar(self):
		return BMWM3()

	def createEnemyCar(self):
		return AudiA6()

class MercedesVsVW(CreateRace):
	def createMyCar(self):
		return MercedesAMG()
		
	def createEnemyCar(self):
		return VWGolf()

class ParkingPodLidlem:
	def __init__(self, factory):
		self.my_factory = factory
		self.my_car = self.my_factory.createMyCar()
		self.enemy_car = self.my_factory.createEnemyCar()

	def begin_race(self):
		self.my_car.race(self.enemy_car)

fab1 = ParkingPodLidlem(BmwVsAudi())
fab2 = ParkingPodLidlem(MercedesVsVW())

fab1.begin_race()
fab2.begin_race()