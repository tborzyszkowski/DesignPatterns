require_relative '../lib/simple_factory'
require_relative '../lib/factory_method'
require_relative '../lib/abstract_factory'
require_relative '../lib/class_registration_factory'
require 'benchmark'
require 'benchmark-memory'

def test_simple_factory
  100_000.times { SimpleMealFactory.instance.serve_meal('Supper', 'Pizza') }
end

def test_factory_method
  breakfast = Breakfast.new
  100_000.times { breakfast.meal('Pizza') }
end

def test_abstract_factory
  factory = PizzaFactory.instance
  100_000.times { factory.serve_meal }
end

def test_reflection_factory
  register('pizza', MealRegistration, ['Pizza'])
  100_000.times { create('pizza').get_meal }
end

Benchmark.bmbm do |x|
  x.report('Simple factory')   { test_simple_factory     }
  x.report('Factory method')   { test_factory_method     }
  x.report('Abstract factory') { test_abstract_factory   }
  x.report('Registr. w. ref.') { test_reflection_factory }
end

Benchmark.memory do |x|
  x.report('Simple factory')   { test_simple_factory     }
  x.report('Factory method')   { test_factory_method     }
  x.report('Abstract factory') { test_abstract_factory   }
  x.report('Registr. w. ref.') { test_reflection_factory }
end
