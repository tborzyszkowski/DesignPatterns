from monster_manager import MonsterManager
from monster_prototype import Monster


def main():
    manager = MonsterManager()
    manager.set_monster(1, Monster(60, 80, 100, ['helmet'], ['sword', 'spikes']))
    manager.set_monster(2, Monster(30, 40, 60, ['hauberk'], ['sword']))
    manager.set_monster(3, Monster(90, 70, 120, ['plate armor'], []))

    manager.set_monster(4, manager.get_monster(1))
    manager.get_monster(4).set_hp(150)

    manager.get_monster(1).show()
    manager.get_monster(4).show()

    manager.set_monster(5, manager.get_monster(1).copy())
    manager.get_monster(5).set_hp(50)

    manager.get_monster(1).show()
    manager.get_monster(5).show()


if __name__ == '__main__':
    main()
