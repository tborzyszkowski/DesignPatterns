import time

from food_store import FoodStore
from menu.burritos.con_carne import BurritoConCarne
from menu.burritos.grilled_chicken import BurritoGrilledChicken
from menu.burritos.pork import BurritoPork
from menu.burritos.pulled_chicken import BurritoPulledChicken
from menu.burritos.vegan import BurritoVegan

start_time = time.time()

store = FoodStore()
burrito = BurritoConCarne()
burrito = BurritoGrilledChicken()
burrito = BurritoPork()
burrito = BurritoPulledChicken()
burrito = BurritoVegan()
for i in range(100000):
    store = FoodStore()
    burrito = store.order_food("burrito_con_carne")
    burrito = store.order_food("burrito_grilled_chicken")
    burrito = store.order_food("burrito_pork")
    burrito = store.order_food("burrito_pulled_chicken")
    burrito = store.order_food("burrito_vegan")

end_time = time.time() - start_time