class MealRegistration
  attr_reader :meal

  def initialize(input)
    @meal = input
  end

  def get_meal
    @meal
  end
end

@registered = {}

def register(reference_name, class_name, params = [])
  @registered[reference_name] = { class_name: class_name, params: [params].flatten }
end

def create(reference_name)
  h = @registered[reference_name]
  h[:class_name].new(*(h[:params]))
end
