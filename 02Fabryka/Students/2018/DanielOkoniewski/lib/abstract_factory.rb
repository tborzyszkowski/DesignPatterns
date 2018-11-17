require_relative 'factory_method'
require 'singleton'

class AbstractBreakfastFactory
  include Singleton
  def serve_meal
    raise NotImplementedError
  end
end

class PancakesFactory < AbstractBreakfastFactory
  include Singleton
  def serve_meal
    Pancakes.new
  end
end

class ScrambledEggsFactory < AbstractBreakfastFactory
  include Singleton
  def serve_meal
    ScrambledEggs.new
  end
end

class AbstractLunchFactory
  include Singleton
  def self.serve_meal
    raise 'Abstract method called'
  end
end

class CheeseBurgerFactory < AbstractLunchFactory
  include Singleton
  def serve_meal
    CheeseBurger.new
  end
end

class VegeBurgerFactory < AbstractLunchFactory
  include Singleton
  def serve_meal
    VegeBurger.new
  end
end

class AbstractSupperFactory
  include Singleton

  def self.serve_meal
    raise 'Abstract method called'
  end
end

class WhiskeyFactory < AbstractSupperFactory
  include Singleton
  def serve_meal
    Whiskey.new
  end
end

class WafflesFactory < AbstractSupperFactory
  include Singleton
  def serve_meal
    Waffles.new
  end
end

class PizzaFactory < AbstractSupperFactory
  include Singleton
  def serve_meal
    Pizza.new
  end
end
