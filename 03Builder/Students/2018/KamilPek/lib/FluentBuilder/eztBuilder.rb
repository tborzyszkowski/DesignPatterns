require_relative 'train'
require_relative 'trainBuilder'
class EztBuilder < TrainBuilder
  @@ezt = nil

  def initialize
    @@ezt = Train.new("EZT")
  end

  def buildModel
    @@ezt["model"] = "ED161"
  end

  def buildEngine
    @@ezt["engine"] = "2400kW"
  end

  def buildSeats
    @@ezt["seats"] = "354"
  end

  def buildWifi
    @@ezt["wifi"] = "TAK"
  end

  def show
    @@ezt.show
  end
end
