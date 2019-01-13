import threading


class SingletonSetting(object):
    threadingLock = threading.Lock()
    __instance = None
    settingVal = 1

    def __new__(cls):
        if not cls.__instance:
            with SingletonSetting.threadingLock:
                if not cls.__instance:
                    cls.__instance = object.__new__(cls)
                    SingletonSetting.__instance.__setting_val = 1
                    SingletonSetting.__instance.__user_list = []
        return cls.__instance
