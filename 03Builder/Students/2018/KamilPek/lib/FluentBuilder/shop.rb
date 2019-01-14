require_relative 'trainBuilder'
class Shop
  @@trainBuilder = nil

  def train(trainBuilder)
    @@trainBuilder = trainBuilder
  end

  def build
    @@trainBuilder.buildModel
    @@trainBuilder.buildEngine
    @@trainBuilder.buildSeats
    @@trainBuilder.buildWifi
    @@trainBuilder.show    
  end
end
