class TrainBuilder
  def buildModel
    raise NotImplementedError
  end

  def buildEngine
    raise NotImplementedError
  end

  def buildSeats
    raise NotImplementedError
  end

  def buildWifi
    raise NotImplementedError
  end

  def show
    raise NotImplementedError
  end
end
