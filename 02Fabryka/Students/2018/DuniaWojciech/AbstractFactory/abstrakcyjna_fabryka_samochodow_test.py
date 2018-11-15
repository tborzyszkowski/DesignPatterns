from abstrakcyjna_fabryka_samochodow_osobowych import FabrykaSamochodowOsobowych
from abstrakcyjna_fabryka_czesci_osobowych import FabrykaCzesciOsobowych
from abstrakcyjna_fabryka_samochodow_ciezarowych import FabrykaSamochodowCiezarowych
from abstrakcyjna_fabryka_czesci_ciezarowych import FabrykaCzesciCiezarowych


def main():
    print('\nAbstrakcyjna fabryka samochodów osobowych, używająca abstrakcyjnej fabryki części s.osobowych:')
    fabryka_czesci = FabrykaCzesciOsobowych()
    fabryka_samochodow = FabrykaSamochodowOsobowych(fabryka_czesci)
    fabryka_samochodow.wytworz_samochod()
    fabryka_samochodow.specyfikacja_samochodu()

    print('\nAbstrakcyjna fabryka samochodów cieżarowych, używająca abstrakcyjnej fabryki części s.cieżarowych:')
    fabryka_czesci = FabrykaCzesciCiezarowych()
    fabryka_samochodow = FabrykaSamochodowCiezarowych(fabryka_czesci)
    fabryka_samochodow.wytworz_samochod()
    fabryka_samochodow.specyfikacja_samochodu()


if __name__ == '__main__':
    main()
