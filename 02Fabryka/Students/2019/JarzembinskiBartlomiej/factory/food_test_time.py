import time

from food_store import FoodStore

start_time = time.time()

store = FoodStore()
for i in range(100001):
  burrito = store.order_food("burrito_con_carne")
  burrito = store.order_food("burrito_grilled_chicken")
  burrito = store.order_food("burrito_pork")
  burrito = store.order_food("burrito_pulled_chicken")
  burrito = store.order_food("burrito_vegan")

end_time = time.time() - start_time