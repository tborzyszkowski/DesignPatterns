class Drive
  attr_accessor :size, :name, :manufacturer

  def initialize(size, name, manu)
    @size         = size
    @name         = name
    @manufacturer = manu
  end
end
