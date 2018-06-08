require_relative 'computer'
require_relative 'flyweight_components_factory'
require 'singleton'

class ComputerBuilder
  include Singleton
  attr_accessor :computer, :factory

  def initialize
    @factory = FlyweightComponentsFactory.instance
  end

  def build
    @computer = Computer.new
    self
  end

  def insert_ram(ram)
    @computer.ram = @factory.create(ram)
    self
  end

  def insert_cpu(cpu)
    @computer.cpu = @factory.create(cpu)
    self
  end

  def insert_gpu(gpu)
    @computer.gpu = @factory.create(gpu)
    self
  end

  def insert_drive(drive)
    @computer.drive = @factory.create(drive)
    self
  end

  def finish
    @computer
  end
end
