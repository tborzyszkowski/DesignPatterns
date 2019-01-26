from monster_manager import MonsterManager
from monster_prototype import Monster, Dzida


def main():
    # konfiguracja dzidy
    dzida = Dzida('Dzida bojowa')
    dzida1 = Dzida('Przeddzidzie dzidy')
    dzida2 = Dzida('Sroddzidzie dzidy')
    dzida3 = Dzida('Zadzidzie dzidy')
    dzida1_1 = Dzida('Przeddzidzie przeddzidzia dzidy')
    dzida1_2 = Dzida('Sroddzidzie przeddzidzia dzidy')
    dzida1_3 = Dzida('Zadzidzie przeddzidzia dzidy')
    dzida2_1 = Dzida('Przeddzidzie sroddzidzia dzidy')
    dzida2_2 = Dzida('Sroddzidzie sroddzidzia dzidy')
    dzida2_3 = Dzida('Zadzidzie sroddzidzia dzidy')
    dzida3_1 = Dzida('Przeddzidzie zadzidzia dzidy')
    dzida3_2 = Dzida('Sroddzidzie zadzidzia dzidy')
    dzida3_3 = Dzida('Zadzidzie zadzidzia dzidy')
    dzida1.set_dzida(dzida1_1, dzida1_2, dzida1_3)
    dzida2.set_dzida(dzida2_1, dzida2_2, dzida2_3)
    dzida3.set_dzida(dzida3_1, dzida3_2, dzida3_3)
    dzida.set_dzida(dzida1, dzida2, dzida3)

    manager = MonsterManager()
    manager.set_monster(1, Monster(60, dzida))
    manager.set_monster(2, Monster(30, dzida))
    manager.set_monster(3, Monster(90, dzida))

    print('Zmiany bez deep copy')
    manager.set_monster(4, manager.get_monster(1))
    manager.get_monster(4).set_hp(150)
    manager.get_monster(4).set_weapon(None)
    manager.get_monster(1).show()
    manager.get_monster(4).show()

    print('Roznice po uzyciu deep copy')
    manager.get_monster(1).set_weapon(dzida)
    manager.set_monster(5, manager.get_monster(1).deep_copy_pickle()) # lub deep_copy()
    manager.get_monster(5).set_hp(50)
    manager.get_monster(5).set_weapon(None)
    manager.get_monster(1).show()
    manager.get_monster(5).show()


if __name__ == '__main__':
    main()
