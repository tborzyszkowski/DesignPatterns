class PbxBuilder
  def buildModel
    raise NotImplementedError
  end

  def buildBilling
    raise NotImplementedError
  end

  def buildRecorder
    raise NotImplementedError
  end

  def buildService
    raise NotImplementedError
  end

  def show
    raise NotImplementedError
  end

  def showShort
    raise NotImplementedError
  end
end
