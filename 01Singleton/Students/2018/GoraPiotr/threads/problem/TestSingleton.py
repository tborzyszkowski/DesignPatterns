import unittest
import threading

from SingletonSetting import SingletonSetting


class TestSingleton(unittest.TestCase):
    singletonList = {}

    def test_threads_problem(self):

        threads = []
        for iterator in range(10):
            try:
                for i in range(10):
                    thread = threading.Thread(target=TestSingleton.make_setting_setting, name='th' + format(i),
                                              args=())
                    threads.append(thread)
                    thread.start()
            except:
                print("Error")

        for x in threads:
            x.join()

        print('\n\nsingleton list: ' + str(self.singletonList))
        print('singleton list length: ' + str(len(self.singletonList)))

    @classmethod
    def make_setting_setting(cls):
        obj = SingletonSetting()
        cls.singletonList[id(obj)] = obj
        return


if __name__ == '__main__':
    unittest.main()
