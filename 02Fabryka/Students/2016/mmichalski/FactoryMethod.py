from abc import ABC, abstractmethod

class PizzaTestDrive():
    def __init__(self):
        self.nyStore = NYPizzaStore()
        self.chicagoStore = ChicagoPizzaStore()

        pizza = self.nyStore.orderPizza("cheese")
        print("Ethan ordered a " + pizza.getName() + "\n")

        pizza = self.chicagoStore.orderPizza("cheese")
        print("Joel ordered a " + pizza.getName() + "\n")


class PizzaStore(ABC):
    @abstractmethod
    def createPizza(self, item):
        pass

    def orderPizza(self, type):
        self.pizza = self.createPizza(type)
        print("--- Making a " + self.pizza.getName() + " ---")
        self.pizza.prepare();
        self.pizza.bake();
        self.pizza.cut();
        self.pizza.box();
        return self.pizza;

class Pizza(ABC):
    def __init__(self):
        self.name = ''
        self.dough = ''
        self.sauce = ''
        self.toppings = []

    def prepare(self):
        print("Preparing " + self.name)
        print("Tossing dough...")
        print("Adding sauce...")
        print("Adding toppings: ")
        for topping in self.toppings:
            print("   " + topping)

    def bake(self):
        print ("Bake for 25 minutes at 350")

    def cut(self):
        print ("Cutting the pizza into diagonal slices")

    def box(self):
        print ("Place pizza in official PizzaStore box")

    def getName(self):
        return self.name

    def __str__(self):
        display = ''
        display += "---- " + self.name + " ----\n"
        display += self.dough + "\n"
        display += self.sauce + "\n"
        for topping in self.toopings:
            display += str(topping) + "\n"
        return display


##Chicago
class ChicagoPizzaStore(PizzaStore):
    def __init__(self):
        pass
    def createPizza(self, item):
        if item == "cheese":
            return ChicagoStyleCheesePizza()
        elif item == "pepperoni":
            return ChicagoStyleClamPizza()
        else:
            return None

class ChicagoStyleCheesePizza(Pizza):
    def __init__(self):
        self.name = "Chicago Style Deep Dish Cheese Pizza"
        self.dough = "Extra Thick Crust Dough"
        self.sauce = "Plum Tomato Sauce"
        self.toppings = ["Shredded Mozzarella Cheese"]
    def cut(self):
        print ("Cutting the pizza into square slices")

class ChicagoStyleClamPizza(Pizza):
    def __init__(self):
        self.name = "Chicago Style Clam Pizza"
        self.dough = "Extra Thick Crust Dough"
        self.sauce = "Plum Tomato Sauce"
        self.toppings = ["Shredded Mozzarella Cheese"]
        self.toppings = ["Frozen Clams from Chesapeake Bay"]

        def cut(self):
            print("Cutting the pizza into square slices")

### NY
class NYPizzaStore(PizzaStore):
    def __init__(self):
        pass
    def createPizza(self, item):
        if item == "cheese":
            return NYStyleCheesePizza()
        elif item == "clam":
            return NYStyleClamPizza()
        else:
            return None


class NYStyleCheesePizza(Pizza):
    def __init__(self):
        self.name = "NY Style Sauce and Cheese Pizza"
        self.dough = "Thin Crust Dough"
        self.sauce = "Marinara Sauce"
        self.toppings = ["Grated Reggiano Cheese"]

class NYStyleClamPizza(Pizza):
    def __init__(self):
        self.name = "NY Style Clam Pizza"
        self.dough = "Thin Crust Dough"
        self.sauce = "Marinara Sauce"
        self.toppings = ["Grated Reggiano Cheese"]
        self.toppings = ["Fresh Clams from Long Island Sound"];

p = PizzaTestDrive()