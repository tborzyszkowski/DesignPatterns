from abc import ABCMeta, abstractmethod


class Port(metaclass=ABCMeta):
    @abstractmethod
    def __str__(self):
        pass

class HTTPPort(Port):
    def __str__(self):
        return '80'

class HTTPSecurePort(Port):
    def __str__(self):
        return '8443'

class MQTTPort(Port):
    def __str__(self):
        return '8883'

class MQTTWSPort(Port):
    def __str__(self):
        return '443'

class AMQPPort(Port):
    def __str__(self):
        return '5671'

class AMQPWSPort(Port):
    def __str__(self):
        return '5773'