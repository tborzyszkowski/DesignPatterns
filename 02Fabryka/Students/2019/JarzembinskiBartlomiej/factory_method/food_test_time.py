import time

from store.burrito_food_store import BurritoFoodStore

start_time = time.time()

store = BurritoFoodStore()
for i in range(100001):
  burrito = store.order_food("con_carne")
  burrito = store.order_food("grilled_chicken")
  burrito = store.order_food("pork")
  burrito = store.order_food("pulled_chicken")
  burrito = store.order_food("vegan")

end_time = time.time() - start_time