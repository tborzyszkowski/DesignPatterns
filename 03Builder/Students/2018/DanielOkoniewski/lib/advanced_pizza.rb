class AdvancedPizza
  def initialize(vegetables, cheeses, meats, sauce, size)
    @vegetables = vegetables
    @cheeses    = cheeses
    @meats      = meats
    @sauce      = sauce
    @size       = size
  end
end

class AdvancedPizza2
  attr_accessor :vegetables, :cheeses, :meats, :sauce, :size
  def initialize
    @vegetables, @cheeses, @meats = [], [], []
  end
end

class Vegetable
  attr_accessor :name
  def initialize(input)
    @name = input
  end
end

class Cheese
  attr_accessor :name
  def initialize(input)
    @name = input
  end
end

class Meat
  attr_accessor :name
  def initialize(input)
    @name = input
  end
end

class AdvancedPizzaFactory
  include Singleton

  def make_pizza(vegetable, cheese, meat, sauce, size)
    veggies, cheeses, meats = [], [], []
    vegetable.each { |veg| veggies << Vegetable.new(veg) }
    cheese.each    { |che| cheeses << Cheese.new(che)    }
    meat.each      { |mea| meats   << Meat.new(mea)      }
    AdvancedPizza.new(veggies, cheeses, meats, sauce, size)
  end
end

class AdvancedPizzaBuilder
  def build
    @pizza = AdvancedPizza2.new
    self
  end

  def get
    @pizza
  end

  def add_veggie(name)
    @pizza.vegetables << Vegetable.new(name)
    self
  end

  def add_cheese(name)
    @pizza.cheeses << Cheese.new(name)
    self
  end

  def add_meat(name)
    @pizza.meats << Meat.new(name)
    self
  end

  def set_sauce(name)
    @pizza.sauce = name
    self
  end

  def set_size(size)
    @pizza.size = size
    self
  end
end
