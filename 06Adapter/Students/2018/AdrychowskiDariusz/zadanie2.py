class Koparka:

    def __init__(self, name):
        self.name = name

    def kopanie(self):
        return 'kopie duzo i szybko'


class Kopacz:

    def __init__(self, name):
        self.name = name

    def kop_recznie(self):
        return 'Kopie powoli, ale dokladnie'


class KopanieAdapter(object):

    def __init__(self, maszyna, operacja):
        self.maszyna = maszyna
        self.operacja = operacja

    def __getattr__(self, item):
        return getattr(self.maszyna, item)


if __name__ == "__main__":

    kopanie1 = Koparka("Duza koparka")
    duzoIszybko = KopanieAdapter(kopanie1, kopanie1.kopanie)
    kopanie2 = Kopacz("Ziutek")
    powoliIdokladnie = KopanieAdapter(kopanie2, kopanie2.kop_recznie)

    for kop in (duzoIszybko, powoliIdokladnie):
        print(kop.name, ' ', kop.operacja())
