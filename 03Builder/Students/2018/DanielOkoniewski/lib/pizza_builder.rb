require '../lib/helpers/factory_method'

class PizzaBuilder
  attr_accessor :pizza

  def get
    @pizza
  end

  def build
    @pizza = Pizza.new
    self
  end

  def dish
    @pizza.dish = 'Pizza'
    self
  end

  def cutlery
    @pizza.cutlery = 'Your hands'
    self
  end
end
