#!/usr/bin/python3
# Bartosz Pawlowski 235403
# Python3

from abc import ABC, abstractmethod

### Visitor ###


class OrderPart(ABC):
    @abstractmethod
    def accept(self, visitor):
        raise NotImplementedError


class Customer(OrderPart):
    def __init__(self, name, phone, mail):
        self.name = name
        self.phone = phone
        self.mail = mail

    def accept(self, visitor):
        visitor.visit_customer(self)


class Product(OrderPart):
    def __init__(self, name, price, count):
        self.name = name
        self.price = price
        self.count = count

    def accept(self, visitor):
        visitor.visit_product(self)


class Address(OrderPart):
    def __init__(self, street, building, city, post):
        self.street = street
        self.building = building
        self.city = city
        self.post = post

    def accept(self, visitor):
        visitor.visit_address(self)


class Order(OrderPart):
    def __init__(self, id, products, address, customer):
        self.id = id
        self.products = products
        self.address = address
        self.customer = customer

    def accept(self, visitor):
        visitor.visit_order(self)
        for product in self.products:
            product.accept(visitor)
        self.address.accept(visitor)
        self.customer.accept(visitor)


class OrderPartVisitor(ABC):
    @abstractmethod
    def visit_customer(self, part):
        raise NotImplementedError

    @abstractmethod
    def visit_product(self, part):
        raise NotImplementedError

    @abstractmethod
    def visit_address(self, part):
        raise NotImplementedError

    @abstractmethod
    def visit_order(self, part):
        raise NotImplementedError


class OrderPartReportVisitor(OrderPartVisitor):
    def __init__(self, report):
        self.report = report

    def visit_customer(self, cust):
        self.report.content += cust.name + ' ' + cust.phone + ' ' + cust.mail + '\n'

    def visit_product(self, prod):
        self.report.content += prod.name + ' ' + str(prod.price) + '\n'

    def visit_address(self, addr):
        self.report.content += addr.street + ' ' + \
            addr.building + ' ' + addr.city + '\n'

    def visit_order(self, order):
        self.report.content += 'Zamówienie' + '\n'


### Koniec Visitora ###

### Strategie ###

class WriteStrategy(ABC):

    @abstractmethod
    def __init__(self, path):
        raise NotImplementedError

    @abstractmethod
    def save(self, content):
        raise NotImplementedError


class WriteStrategyEx(WriteStrategy):

    def __init__(self, path):
        try:
            self.f = open(path, 'a')
        except IOError as e:
            print(e)

    def save(self, content):
        self.f.write(content)


class WriteStrategyNEx(WriteStrategy):

    def __init__(self, path):
        try:
            self.f = open(path, 'a+')
        except IOError as e:
            print(e)

    def save(self, content):
        self.f.write(content)


class Report:
    def __init__(self, path):
        self.path = path
        self.content = ''
        self.strategy = None

    def set_strategy(self, strategy):
        self.strategy = strategy(self.path)

    def save(self):
        if not self.strategy:
            self.set_strategy(WriteStrategyEx)
        if self.strategy:
            self.strategy.save(self.content)

### Koniec Strategii ###


if __name__ == '__main__':
    cust1 = Customer('Jan Borysiuk', '56787654', 'jan@borysiuk.pl')
    cpu1 = Product('Intel Core i5 8300', 400.00, 5)
    mb1 = Product('Asus MBXY23', 300.00, 4)
    mem1 = Product('Corsair 16GB', 300, 6)
    addr1 = Address('Niepolomnicka', '23/4', 'Gdansk', '80-180')
    order = Order(7, (cpu1, mb1), addr1, cust1)
    visitor = OrderPartReportVisitor(Report('report.txt'))
    visitor.report.set_strategy(WriteStrategyNEx)
    order.accept(visitor)
    visitor.report.save()
