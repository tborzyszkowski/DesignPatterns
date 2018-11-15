from abstrakcyjna_fabryka_samochodow_osobowych_refleksja import FabrykaSamochodowOsobowych
from abstrakcyjna_fabryka_czesci_osobowych_refleksja import FabrykaCzesciOsobowych


def main():
    print('\nAbstrakcyjna fabryka samochodów osobowych, używająca abstrakcyjnej fabryki części s.osobowych:')
    fabryka_czesci = FabrykaCzesciOsobowych()
    fabryka_samochodow = FabrykaSamochodowOsobowych(fabryka_czesci)
    fabryka_samochodow.wytworz_samochod()
    fabryka_samochodow.specyfikacja_samochodu()


if __name__ == '__main__':
    main()
