require_relative 'cpu'
require_relative 'drive'
require_relative 'gpu'
require_relative 'ram'
require_relative 'command'
require_relative 'memento'

# This is a facade of complex computer object
class Computer
  attr_accessor :ram, :drive, :cpu, :gpu, :model_name, :state, :id
  include ComputerCommands

  def execute(command)
    command.execute(self)
  end

  def build
    ComputerBuilder.instance.build
  end
end
