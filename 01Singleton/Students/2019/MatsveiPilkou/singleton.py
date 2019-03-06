import threading

class Singleton:

    instanse = None
    lock = threading.Lock()          

    def getInstanse(self):
        with Singleton.lock:
            
            # print("singleton")
            # print(Singleton)
            # print("self")
            # print(self)
            # print("self.class")
            # print(self.__class__)
            
            if (type(self) is Singleton):
                if (Singleton.instanse == None):
                    Singleton.instanse = self
                return Singleton.instanse
            else:
                if (self.__class__.instanse == None):
                    self.__class__.instanse = self
                return self.__class__.instanse



class ChildSingleton(Singleton):
    instanse = None

    

    
