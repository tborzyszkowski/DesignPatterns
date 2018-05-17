require_relative 'factory_method'
require 'singleton'

class SimpleMealFactory
  include Singleton

  def serve_meal(type, dish)
    meal = case type
           when 'Breakfast'
             case dish
             when 'Ham & mustard sandwich'    then HamMustardSandwich.new
             when 'Cheese & mayo sandwich'    then CheeseMayoSandwich.new
             when 'Scrambled eggs'            then ScrambledEggs.new
             when 'Scrambled eggs with bacon' then ScrambledEggsBacon.new
             when 'Pancakes'                  then Pancakes.new
             end
           when 'Lunch'
             case dish
             when 'Beef cheeseburger'            then CheeseBurger.new
             when 'Spinach burger'               then VegeBurger.new
             when 'Tofu cheeseburger'            then TofuCheeseBurger.new
             when 'Fish & fries'                 then FishAndChips.new
             when 'Tomato cream soup with basil' then TomatoCream.new
             end
           when 'Supper'
             case dish
             when 'Waffles with jam'     then Waffles.new
             when 'Craft beer'           then CraftBeer.new
             when 'Pizza'                then Pizza.new
             when 'Kebab'                then Kebab.new
             when 'Neat Whiskey, no ice' then Whiskey.new
             end
           end
    meal
  end
end
