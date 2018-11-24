from SingletonSetting import SingletonSetting


class SingletonUserSetting(SingletonSetting):

    userSetting = 'user setting'

    def __new__(cls):
        return super(SingletonUserSetting, cls).__new__(cls)
