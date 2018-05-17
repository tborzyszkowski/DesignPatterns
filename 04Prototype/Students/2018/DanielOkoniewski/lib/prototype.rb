class Pancake
  attr_accessor :jam, :flour

  def initialize(jam = nil, flour = nil)
    @jam   = jam
    @flour = flour
  end

  def shallow_copy
    pancake = Pancake.new
    instance_variables.each do |variable|
      pancake.instance_variable_set(variable, instance_variable_get(variable))
    end
    pancake
  end

  def deep_copy(object = self)
    copy = object.class.new
    object.instance_variables.each do |variable|
      var = object.instance_variable_get(variable)
      if var.is_a? String
        copy.instance_variable_set(variable, var)
      else
        copy.instance_variable_set(variable, deep_copy(var))
      end
    end
    copy
  end
end

class Jam
  attr_accessor :fruit, :sugar

  def initialize(fruit = nil, sugar = 'None')
    @fruit = fruit
    @sugar = sugar
  end
end

class Fruit
  attr_accessor :name

  def initialize(name = 'name')
    @name = name
  end
end

# Some lazy basic testing
strawberry = Fruit.new('Strawberry')
jam = Jam.new(strawberry)
pancake1 = Pancake.new(jam, 'Wheat')
pancake2 = pancake1.shallow_copy
pancake3 = pancake1.deep_copy
p '--------------------- Pancake 1 - original -----------------'
p pancake1
p '--------------------- Pancake 2 - shallow ------------------'
p pancake2
p '--------------------- Pancake 3 - deep ---------------------'
p pancake3
