class Meal
  attr_accessor :dish, :cutlery

  def serve(type)
    case type
    when 'Breakfast' then Breakfast.new
    when 'Lunch'     then Lunch.new
    when 'Supper'    then Supper.new
    end
  end
end

class Breakfast < Meal
  def meal(dish)
    case dish
    when 'Ham & mustard sandwich'    then HamMustardSandwich.new
    when 'Cheese & mayo sandwich'    then CheeseMayoSandwich.new
    when 'Scrambled eggs'            then ScrambledEggs.new
    when 'Scrambled eggs with bacon' then ScrambledEggsBacon.new
    when 'Pancakes'                  then Pancakes.new
    end
  end
end

class HamMustardSandwich < Breakfast
  def initialize
    @dish    = 'Ham & mustard sandwich'
    @cutlery = 'Your hands'
  end
end

class CheeseMayoSandwich < Breakfast
  def initialize
    @dish    = 'Cheese & mayo sandwich'
    @cutlery = 'Your hands'
  end
end

class ScrambledEggs < Breakfast
  def initialize
    @dish    = 'Scrambled eggs'
    @cutlery = 'Fork'
  end
end

class ScrambledEggsBacon < Breakfast
  def initialize
    @dish    = 'Scrambled eggs with bacon'
    @cutlery = 'Fork'
  end
end

class Pancakes < Breakfast
  def initialize
    @dish    = 'Pancakes'
    @cutlery = 'Fork & knife'
  end
end

class Lunch < Meal
  def meal(dish)
    case dish
    when 'Beef cheeseburger'            then CheeseBurger.new
    when 'Spinach burger'               then VegeBurger.new
    when 'Tofu cheeseburger'            then TofuCheeseBurger.new
    when 'Fish & fries'                 then FishAndChips.new
    when 'Tomato cream soup with basil' then TomatoCream.new
    end
  end
end

class CheeseBurger < Lunch
  def initialize
    @dish    = 'Beef cheeseburger'
    @cutlery = 'Your Hands'
  end
end

class VegeBurger < Lunch
  def initialize
    @dish    = 'Spinach burger'
    @cutlery = 'Your Hands'
  end
end

class TofuCheeseBurger < Lunch
  def initialize
    @dish    = 'Tofu cheeseburger'
    @cutlery = 'Your Hands'
  end
end

class FishAndChips < Lunch
  def initialize
    @dish    = 'Fish & fries'
    @cutlery = 'Fork & knife'
  end
end

class TomatoCream < Lunch
  def initialize
    @dish    = 'Tomato cream soup with basil'
    @cutlery = 'Spoon'
  end
end

class Supper < Meal
  def meal(dish)
    case dish
    when 'Waffles with jam'     then Waffles.new
    when 'Craft beer'           then CraftBeer.new
    when 'Pizza'                then Pizza.new
    when 'Kebab'                then Kebab.new
    when 'Neat Whiskey, no ice' then Whiskey.new
    end
  end
end

class Waffles < Supper
  def initialize
    @dish    = 'Waffles with jam'
    @cutlery = 'Your hands & knife'
  end
end

class CraftBeer < Supper
  def initialize
    @dish = 'Craft beer'
    @cutlery = 'TeKu glass'
  end
end

class Pizza < Supper
  def initialize
    @dish    = 'Pizza'
    @cutlery = 'Your hands'
  end
end

class Kebab < Supper
  def initialize
    @dish    = 'Kebab'
    @cutlery = 'Your hands & fork'
  end
end

class Whiskey < Supper
  def initialize
    @dish    = 'Neat Whiskey, no ice'
    @cutlery = 'Glass'
  end
end
