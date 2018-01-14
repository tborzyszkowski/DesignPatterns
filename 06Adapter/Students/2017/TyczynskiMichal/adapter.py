from abc import ABCMeta, abstractmethod

class EnemyAttacker(metaclass = ABCMeta):
    @abstractmethod
    def fireWeapon(self): pass
    @abstractmethod
    def driveForward(self): pass
    @abstractmethod
    def changeDriver(self, name): pass

class EnemyTank(EnemyAttacker):
    def fireWeapon(self):
        print( "Tank shots for 123 damage")
    def driveForward(self):
        print("GO!")
    def changeDriver(self, name):
        print("Assigned %s to drive" %(name))

class EnemyRobot:
	def handsAttack(self):
		print("Robot attacked with hands for over 9000 dmg.")

	def walk(self):
		print("Robot walks forward.")

	def reactToHuman(self, driver_name):
		print("Robot kills tank driver named " + driver_name)


class EnemyRobotAdapter(EnemyAttacker):
	def __init__(self, robot):
		self.robot = robot

	def fireWeapon(self):
		return self.robot.handsAttack()

	def driveForward(self):
		return self.robot.walk()

	def changeDriver(self, name):
		return self.robot.reactToHuman(name)



tank = EnemyTank();
theRobot = EnemyRobot()
robotAdapter = EnemyRobotAdapter(theRobot)
theRobot.reactToHuman("Paul")
theRobot.walk()
theRobot.handsAttack()

tank.changeDriver("Frank")
tank.driveForward()
tank.fireWeapon()

# robot with adapter
robotAdapter.changeDriver("Mark")
robotAdapter.driveForward()
robotAdapter.fireWeapon()
