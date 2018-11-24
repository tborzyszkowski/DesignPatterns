import unittest

from SingletonSetting import SingletonSetting
from SingletonUserSetting import SingletonUserSetting


class TestSingleton(unittest.TestCase):

    def test_inherited_solution(self):
        singleton_setting_1 = SingletonSetting()
        singleton_setting_2 = SingletonSetting()

        self.assertIs(singleton_setting_1, singleton_setting_2)

        singleton_user_setting_1 = SingletonUserSetting()
        singleton_user_setting_2 = SingletonUserSetting()

        self.assertIs(singleton_user_setting_1, singleton_user_setting_2)

        self.assertIsNot(singleton_setting_1, singleton_user_setting_1)


if __name__ == '__main__':
    unittest.main()
