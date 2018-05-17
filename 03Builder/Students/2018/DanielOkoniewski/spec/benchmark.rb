require_relative '../lib/helpers/abstract_factory'
require_relative '../lib/pizza_builder'
require_relative '../lib/advanced_pizza'
require 'benchmark'

def test_factory_simple
  factory = PizzaFactory.instance
  1_000_000.times { factory.serve_meal }
end

def test_builder_simple
  builder = PizzaBuilder.new
  1_000_000.times { builder.build.cutlery.dish.get }
end

def test_factory_advanced
  factory = AdvancedPizzaFactory.instance
  1_000_000.times { factory.make_pizza(%w[Zucchini Mushrooms], %w[Mozzarella], [], 'Tomato', 30) }
end

def test_builder_advanced
  builder = AdvancedPizzaBuilder.new
  1_000_000.times do
    builder.build.add_veggie('Zucchini').add_veggie('Mushrooms').add_cheese('Mozzarella').set_sauce('Tomato')
      .set_size(30).get
  end
end

Benchmark.bmbm do |x|
  p '------------------------------------'
  p ' Testing creation of simple objects '
  x.report('Abstract factory') { test_factory_simple }
  x.report('Builder')          { test_builder_simple }
end

Benchmark.bmbm do |x|
  p '------------------------------------'
  p 'Testing creation of advanced objects'
  x.report('Abstract factory') { test_factory_advanced }
  x.report('Builder')          { test_builder_advanced }
end
