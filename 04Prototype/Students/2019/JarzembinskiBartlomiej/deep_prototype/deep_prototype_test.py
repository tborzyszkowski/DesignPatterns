import unittest

from computer_manager import ComputerManager
from computer_prototype import Prototype


class TestPrototype(unittest.TestCase):

  def test_shallow_copy(self):
    manager = ComputerManager()
    manager.set_computer("economic", Prototype("Silentium Brutus", "Gigabyte B360M", "400W", "Intel", "i3", "3725", "2", "3Ghz", "Radeon HD6450", "500 GB HDD", "4GB"))

    computer1a = manager.get_computer("economic")
    computer1b = manager.get_computer("economic")
    computer1c = manager.get_computer("economic").clone()

    self.assertTrue(computer1a is computer1b)
    self.assertTrue(computer1a is not computer1c)
    self.assertTrue(computer1a.cpu is computer1c.cpu)

  def test_deep_copy(self):
    manager = ComputerManager()
    manager.set_computer("economic", Prototype("Silentium Brutus", "Gigabyte B360M", "400W", "Intel", "i3", "3725", "2", "3Ghz", "Radeon HD6450", "500 GB HDD", "4GB"))

    computer1a = manager.get_computer("economic")
    computer1b = manager.get_computer("economic").deep_clone()

    self.assertTrue(computer1a is not computer1b)
    self.assertTrue(computer1a.cpu is not computer1b.cpu)
    self.assertTrue(computer1a.cpu.info is not computer1b.cpu.info)
    self.assertTrue(computer1a.cpu.info.model is not computer1b.cpu.info.model)

if __name__ == "__main__":
  unittest.main()
