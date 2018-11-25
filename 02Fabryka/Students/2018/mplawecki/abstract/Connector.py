import random
from faker import Faker
from factory.abstract.ConcreteFactory import  HTTPFactory,AbstractFactory, MQTTFactory,AMQPFactory


class Connector(object):
    def __init__(self,factory):
        self.auth = factory.create_auth()
        self.port = factory.create_port()
        self.parser = factory.create_parser()
        self.person = Faker()
        self.machine = str(factory.machine_uid())
    def read(self,host,path):
        url = self.auth + '://' + host + ':' + str(self.port) + path + self.machine
        print("Connecting to {} on behalf {}".format(url, self.person.name()))


if __name__=='__main__':
    domain = 'service.vts.org'
    path = '/pub/'
    textual = Faker()
    is_secure = bool(random.getrandbits(1))

    for i in range(200):
       for name in  [HTTPFactory,MQTTFactory,AMQPFactory]:
          factory = name(is_secure)
          abstract = isinstance(factory, AbstractFactory)
          print("Is {} instance of AbstractFactory? {} ".format(factory, abstract))
          connector = Connector(factory)
          content = connector.read(domain, path)



