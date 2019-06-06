from functions import progress_bar

class Waiter:

    def update(self, order_id):
        print(f"\nWaiter will serve your order with ID number: {order_id} soon.")
        progress_bar(30,0.01)
        print(f"\nOrder was served.")
