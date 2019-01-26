# Implementacja wzorca Singleton do obslugi dziedziczenia
class Config(object):
    __instance = {}
    
    def __new__(self, username='admin', password='p@ssw0rd'):
        if type(object.__new__(self)).__name__ not in self.__instance:
            self.__instance[type(object.__new__(self)).__name__] = object.__new__(self)
            self.__instance[type(object.__new__(self)).__name__].__user_id = id(self)
            self.__instance[type(object.__new__(self)).__name__].__user_name = username
            self.__instance[type(object.__new__(self)).__name__].__user_pass = password            
            print('Utworzono singleton dla klasy {}'.format(type(object.__new__(self)).__name__))       
        else:
            print('Singleton dla klasy {} istnieje, pobrano referencje'.format(type(object.__new__(self)).__name__)) 
        return self.__instance[type(object.__new__(self)).__name__]

    def printUser(self):
        print('User ID: '+ str(self.__instance[type(self).__name__].__user_id))
        print('User name: '+ str(self.__instance[type(self).__name__].__user_name))
        print('User pass: '+ str(self.__instance[type(self).__name__].__user_pass))
            
    def getConfig(self):
        return self.__instance[type(self).__name__]

    def getId():
        cfg = self.getConfig()
        return id(cfg)

    def setUser(self, userid, name, password):
        self.__instance[type(self).__name__].__user_id = userid
        self.__instance[type(self).__name__].__user_name = name
        self.__instance[type(self).__name__].__user_pass = password