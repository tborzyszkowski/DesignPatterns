class SingletonSetting(object):
    __instance = {}
    settingVal = 1

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
            SingletonSetting.__instance[type(object.__new__(cls)).__name__].__setting_val = 1
            SingletonSetting.__instance[type(object.__new__(cls)).__name__].__user_list = []
        return cls.__instance[type(object.__new__(cls)).__name__]
