from functions import print_greeting
from mexican_restaurant_facade import MexicanRestaurant


def main():
    print_greeting()
    restaurant = MexicanRestaurant()
    restaurant.order_dish()

if __name__ == "__main__":
    main()
