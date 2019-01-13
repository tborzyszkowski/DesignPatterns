import configparser

class Config(object):
    def __init__(self,db):
        self.parser = configparser.ConfigParser()
        self.parser.read('config.ini')
        self.db = db().__str__()

    def getConfig(self):
        for i in self.parser[self.db]:
            print('{} : {}'.format(i,self.parser[self.db][i]))


