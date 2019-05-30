import unittest

from computer_manager import ComputerManager
from computer_prototype import Computer


class TestPrototype(unittest.TestCase):

  def test_shallow_copy(self):
    manager = ComputerManager()
    manager.set_computer("economic", Computer("Silentium Brutus", "Gigabyte B360M", "400W", "Intel i3", "Radeon HD6450", "500 GB HDD", "4GB"))
    manager.set_computer("office", Computer("Cooler Master", "Gigabyte GA-B360M", "420W", "Intel i5", "GeForce GT1030", "500GD SSD", "8GB"))
    manager.set_computer("game", Computer("Silentium Armis", "Gigabyte Z390", "600W", "Intel i9", "GeForce RTX2070", "500GB Nvme", "16GB"))

    computer1a = manager.get_computer("economic")
    computer1b = manager.get_computer("economic")
    computer1c = manager.get_computer("economic").clone()

    self.assertTrue(computer1a is computer1b)
    self.assertTrue(computer1a is not computer1c)

if __name__ == "__main__":
  unittest.main()
