import uuid
from abc import ABCMeta, abstractmethod
from factory.abstract.Parser import HTTPParser, MQTTWSParser, MQTTParser, AMQPWSParser, AMQPParser
from factory.abstract.Port import HTTPPort, MQTTWSPort, MQTTPort, AMQPWSPort, AMQPPort, HTTPSecurePort

"""
MQTT 8883
MQTTWS 443
HTTP 80
HTTPS 443
AMQP 5671
AMQPWS 5773
"""

def Singleton(cls):
    import threading
    lock = threading.RLock()
    instances = {}

    def create(*args):
        with lock:
            try:
                return instances[args]
            except KeyError:
                instances[args] = instance = cls(*args)
                return instance

    return create


class AbstractFactory(metaclass=ABCMeta):
    def __init__(self,is_extcert,nazwa=None):
        self.is_extcert = is_extcert
        self.name = nazwa

    @abstractmethod
    def create_auth(self):
        pass

    @abstractmethod
    def create_port(self):
        pass

    @abstractmethod
    def create_parser(self):
        pass

    @property
    def names(self):
        return self.name
    @names.setter
    def named(self,nazwa):
        self.name=nazwa

    def machine_uid(self):
        return uuid.uuid1();


@Singleton
class HTTPFactory(AbstractFactory):
    def create_auth(self):
        if self.is_extcert:
            return 'https'
        return 'http'

    def create_port(self):
        if self.is_extcert:
            return HTTPSecurePort()
        return HTTPPort()

    def create_parser(self):
        return HTTPParser()

@Singleton
class MQTTFactory(AbstractFactory):
    def create_auth(self):
        if self.is_extcert:
            return 'mqttwss'
        return 'mqtt'

    def create_parser(self):
        if self.is_extcert:
            return MQTTWSParser()
        return MQTTParser()

    def create_port(self):
        if self.is_extcert:
            return MQTTWSPort()
        return MQTTPort()

@Singleton
class AMQPFactory(AbstractFactory):
    def create_auth(self):
        if self.is_extcert:
            return 'amqp'
        return 'amqpws'

    def create_port(self):
        if self.is_extcert:
            return AMQPWSPort()
        return AMQPPort()

    def create_parser(self):
        if self.is_extcert:
            return AMQPWSParser()
        return AMQPParser()
