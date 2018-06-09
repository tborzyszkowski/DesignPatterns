class Ram
  attr_accessor :memory_size, :name, :manufacturer

  def initialize(mem, name, manu)
    @memory_size  = mem
    @name         = name
    @manufacturer = manu
  end
end
