class Cpu
  attr_accessor :frequency, :name, :manufacturer

  def initialize(freq, name, manu)
    @frequency    = freq
    @name         = name
    @manufacturer = manu
  end
end
