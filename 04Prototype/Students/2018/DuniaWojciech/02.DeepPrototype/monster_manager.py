from monster_prototype import Monster, MonsterPrototype


class MonsterManager:
    def __init__(self):
        self._monster_database = {}

    def get_monster(self, name)->MonsterPrototype:
        return self._monster_database[name]

    def set_monster(self, name, monster: MonsterPrototype):
        self._monster_database.update({name: monster})
