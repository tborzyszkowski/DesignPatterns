require_relative 'trainBuilder'
require_relative 'abstractFactory'
class DieselBuilder < TrainBuilder
  @@diesel = nil

  def initialize
    diesel = ST44Factory.instance
    @@diesel = diesel.take_a_ride
  end

  def buildName
    @@diesel["name"] = "ŁTZ M62"
  end

  def buildEngine
    @@diesel["engine"] = "1472kW"
  end

  def buildSeats
    @@diesel["seats"] = "0"
  end

  def build
    self.buildName
    self.buildEngine
    self.buildSeats
    @@diesel.show
  end
end
