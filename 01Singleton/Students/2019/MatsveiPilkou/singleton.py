import threading

class Singleton:

    instanse = None
    lock = threading.Lock()          

    def getInstanse(self):
        with Singleton.lock:
                        
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

    

    
