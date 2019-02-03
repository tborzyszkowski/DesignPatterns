import sys


class Operator:
    def __init__(self, mediator, identity):
        self._mediator = mediator
        self._id = identity

    def getID(self):
        return self._id

    def send(self, message):
        pass

    def receive(self, message):
        pass


class ConcreteOperator(Operator):
    def __init__(self, mediator, identity):
        super().__init__(mediator, identity)

    def send(self, message):
        print("Message '" + message + "' sent by Operator " + str(self._id))
        self._mediator.distribute(self, message)

    def receive(self, message):
        print("Message '" + message + "' received by Operator " + str(self._id))


#
# Mediator
# defines an interface for communicating with Operator objects
#
class Mediator:
    def add(self, operator):
        pass

    def distribute(self, sender, message):
        pass


#
# Concrete Mediator
# implements cooperative behavior by coordinating Colleague objects
# and knows its colleagues
#
class ConcreteMediator(Mediator):
    def __init__(self):
        Mediator.__init__(self)
        self._operators = []

    def add(self, operator):
        self._operators.append(operator)

    def distribute(self, sender, message):
        for operator in self._operators:
            if operator.getID() != sender.getID():
                operator.receive(message)


if __name__ == "__main__":
    mediator = ConcreteMediator()

    c1 = ConcreteOperator(mediator, 1)
    c2 = ConcreteOperator(mediator, 2)
    c3 = ConcreteOperator(mediator, 3)

    mediator.add(c1)
    mediator.add(c2)
    mediator.add(c3)

    c1.send("Hi!");
    c3.send("Hello!");
