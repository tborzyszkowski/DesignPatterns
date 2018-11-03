import time
import threading
# Implementacja wzorca Singleton z zabezpieczeniem tworzenia przez wiele watkow
class Config(object):
    __config_instance = None
    __lock = threading.Lock()
    
    def __new__(self, username='admin', password='p@ssw0rd'):
        if Config.__config_instance == None:
            with Config.__lock:
                if Config.__config_instance == None:
                    Config.__config_instance = object.__new__(self)
                    Config.__config_instance.user_id = id(object.__new__(self))
                    Config.__config_instance.user_name = username
                    Config.__config_instance.user_pass = password
            time.sleep(0.001)
        return Config.__config_instance
               
    @staticmethod
    def getConfig():
        if Config.__config_instance == None:
            Config()
        return Config.__config_instance

    @staticmethod
    def getId():
        return id(Config.__config_instance)

    @staticmethod
    def resetConfig():
        Config.__config_instance = None

    @classmethod
    def printUser(self):
        cfg = Config.getConfig()
        print('User ID: '+ str(cfg.user_id))
        print('Name: '+ cfg.user_name)
        print('Password: '+ cfg.user_pass+'\n')

    @classmethod
    def setUser(self, userid, name, password):
        cfg = Config.getConfig()
        cfg.user_id = userid
        cfg.user_name = name
        cfg.user_pass = password
