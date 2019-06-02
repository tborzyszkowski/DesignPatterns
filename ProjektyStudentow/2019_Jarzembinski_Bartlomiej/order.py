from datetime import datetime
from functions import progress_bar


class SubjectOfObservation:

	def __init__(self):
		self._observers = []

	def attach(self, observer):
		if observer not in self._observers:
			self._observers.append(observer)

	def detach(self, observer):
		try:
			self._observers.remove(observer)
		except ValueError:
			pass

	def notify(self, order_id):
		for observer in self._observers:
			observer.update(order_id)


class Order(SubjectOfObservation):

    def __init__(self, dish):
        SubjectOfObservation.__init__(self)
        self.id = None
        self.order_time = str(datetime.now())[11:19]
        self.dish = dish

    def print_info(self):
        print(f"\nOrder ID: {self.id}",
              f"\nOrder time: {self.order_time}")
        self.dish.print_info()

    def prepare(self):
        print("\nPrepering your order...")
        progress_bar(30,0.02)
        print("\nReady. Wait for waiter.")
        self.notify(self.id)
