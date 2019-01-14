class Train
  attr_accessor :engine, :seats

  def initialize(engine = nil, seats = nil)
    @engine = engine
    @seats = seats
  end

  def shallow_copy
    self.clone
  end

  def deep_copy
    Marshal.load(Marshal.dump(self))
  end
end

class Engine
  attr_accessor :fuel, :power

  def initialize(fuel = nil, power = nil)
    @fuel = fuel
    @power = power
  end
end

class Seats
  attr_accessor :quantity

  def initialize(quantity = nil)
    @quantity = quantity
  end
end

dart_engine = Engine.new('Electric', '2400kW')
dart_seats = Seats.new(354)
dart_0 = Train.new(dart_engine, dart_seats)
dart_1 = dart_0.shallow_copy
puts "original train – " + dart_0.inspect
puts "shallow copy train – " + dart_1.inspect
dart_2 = dart_0.deep_copy
puts "deep copy train – " + dart_2.inspect
