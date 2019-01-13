import unittest

from SingletonSetting import SingletonSetting
from SingletonUserSetting import SingletonUserSetting


class TestSingleton(unittest.TestCase):

    def test_inherited_problem(self):
        singleton_setting = SingletonSetting()
        singleton_user_setting = SingletonUserSetting()
        self.assertIs(singleton_setting, singleton_user_setting)

        singleton_setting.set_setting_val(4)

        self.assertEqual(singleton_setting.get_setting_val(), singleton_user_setting.get_setting_val(), 'incorrect value')


if __name__ == '__main__':
    unittest.main()
