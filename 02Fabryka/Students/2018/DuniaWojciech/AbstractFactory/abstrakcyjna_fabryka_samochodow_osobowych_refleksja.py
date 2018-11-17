from abstrakcyjna_fabryka_samochodow_abstract_class import AbstrakcyjnaFabrykaSamochodow


class FabrykaSamochodowOsobowych(AbstrakcyjnaFabrykaSamochodow):
    def wytworz_samochod(self):
        self.fabryka_karoserii = self.fabryka_czesci.wytworz_karoserie()
        self.fabryka_podwozia = self.fabryka_czesci.wytworz_podwozie()
        self.fabryka_silnika = self.fabryka_czesci.wytworz_silnik()
        self.fabryka_wyposazenia = self.fabryka_czesci.wytworz_wyposazenie()


