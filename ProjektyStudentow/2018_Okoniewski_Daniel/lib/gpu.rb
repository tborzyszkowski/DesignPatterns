class Gpu
  attr_accessor :memory_size, :frequency, :name, :manufacturer

  def initialize(size, freq, name, manu)
    @memory_size  = size
    @frequency    = freq
    @name         = name
    @manufacturer = manu
  end
end
