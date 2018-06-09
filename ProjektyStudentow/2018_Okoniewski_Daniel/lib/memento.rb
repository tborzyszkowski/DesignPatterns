class Memento
  class << self; attr_accessor :mementos end
  attr_accessor :state
  @mementos = {}

  def initialize(state)
    @state = state
  end
end
