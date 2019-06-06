from singleton import Singleton
from store_proxy import StoreProxy
from waiter import Waiter

class MexicanRestaurant(Singleton):
    def order_dish(self):
        self.store = StoreProxy().create_store()

        if self.store:
            self.waiter = Waiter()
            chosen_dish_kind = self.store.choose_dish_kind()
            self.factory = self.store.create_factory(chosen_dish_kind)

            if self.factory:
                order = self.factory.order_dish()
                
                if order:
                    order.id = len(self.store.orders_list) + 1
                    order.attach(self.waiter)
                    self.store.orders_list.append(order)
                    self.store.orders_list[-1].print_info()
                    self.store.orders_list[-1].prepare()
