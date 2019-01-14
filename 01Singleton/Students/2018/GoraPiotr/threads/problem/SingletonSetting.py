import time


class SingletonSetting(object):
    __instance = None

    def __new__(cls):
        if not cls.__instance:
            time.sleep(0.1)
            cls.__instance = object.__new__(cls)
            SingletonSetting.__instance.__setting_val = 1
            SingletonSetting.__instance.__user_list = []
        return cls.__instance

    def set_user_list(self, users: []):
        self.__user_list.append(users)

    def get_user_list(self) -> []:
        return self.__user_list

    def get_setting_val(self) -> int:
        return SingletonSetting.__instance.__setting_val

    def set_setting_val(self, value: int):
        SingletonSetting.__instance.__setting_val = value
