
class AbstractCar(object):
    def __init__(self):
        self.name = ""
        self.price = 0.00
        pass

    def GetName(self):
        return self.name

    def GetPrice(self):
        return self.price


class AbstractDecorator(AbstractCar):
    def __init__(self):
        pass


class Decorator(AbstractDecorator):
    def __init__(self, parent):
        self.car = parent
        self.accessories = ""
        self.surcharge = 0.00


    def GetName(self):
        return self.car.GetName() + " + " + self.accessories


    def GetPrice(self):
        return self.car.GetPrice() + self.surcharge


# -------------------------------------------------------------------------------

class Car(AbstractCar):
    def __init__(self):
        pass

def main():
    # wstawianie danych
    car = Car()
    car.name = "Mazda 3"
    car.price = 30000.00

    # wyswietlenie danych
    print ("Samochod bez dodatkow")
    print ("")
    print ("    Nazwa: %s" % (car.GetName()))
    print ("    Cena:  %1.2f" % (car.GetPrice()))
    print ("")

    # mozna wztawiac dowolne akcesoria i doplaty do ceny - dekorator
    car = Decorator(car)
    car.accessories = "klimatyzacja"
    car.surcharge = 5000.00

    # wyswietlenie danych
    print ("Samochod z klimatyzacja")
    print ("")
    print ("    Nazwa: %s" % (car.GetName()))
    print ("    Cena:  %1.2f" % (car.GetPrice()))
    print ("")

    # mozna wztawiac dowolne akcesoria i doplaty do ceny
    car = Decorator(car)
    car.accessories = "alufelgi"
    car.surcharge = 1000.00

    # wyswietlenie danych
    print ("Samochod z klimatyzacja i alufelgami")
    print ("")
    print ("    Nazwa: %s" % (car.GetName()))
    print ("    Cena:  %1.2f" % (car.GetPrice()))
    print ("")


    # mozna wztawiac dowolne akcesoria i doplaty do ceny
    car = Decorator(car)
    car.accessories = "naglosnienie"
    car.surcharge = 2000.00

    # wyswietlenie danych
    print ("Samochod z klimatyzacja, alufelgami i naglosnieniem")
    print ("")
    print ("    Nazwa: %s" % (car.GetName()))
    print ("    Cena:  %1.2f" % (car.GetPrice()))
    print ("")

# -------------------------------------------------------------------------------

if __name__ == "__main__":
    main()