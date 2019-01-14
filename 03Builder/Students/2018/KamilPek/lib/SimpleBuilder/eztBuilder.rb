require_relative 'trainBuilder'
require_relative 'factoryMethod'
class EztBuilder < TrainBuilder
  @@ezt = nil

  def initialize
    electric = Train.new.ride('EZT')
    @@ezt = electric.model('ED161')
  end

  def buildName
    @@ezt["name"] = "Pesa Dart"
  end

  def buildEngine
    @@ezt["engine"] = "2400kW"
  end

  def buildSeats
    @@ezt["seats"] = "354"
  end

  def build
    self.buildName
    self.buildEngine
    self.buildSeats
    @@ezt.show
  end
end
