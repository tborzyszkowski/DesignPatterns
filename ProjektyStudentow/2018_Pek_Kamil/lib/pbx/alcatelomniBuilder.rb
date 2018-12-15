require_relative 'pbx'
require_relative 'pbxBuilder'
class AlcatelOmniBuilder
  @@pbx = nil

  def initialize
    @@pbx = Pbx.new()
    @@pbx
  end

  def buildModel
    @@pbx.name = "Alcatel OmniPCX"
  end

  def buildBilling
    @@pbx.billing = true
  end

  def buildRecorder
    @@pbx.recorder = true
  end

  def buildService
    @@pbx.service = "ssh"
  end

  def show
    @@pbx.show
  end

  def showShort
    @@pbx.showShort
  end

  def getPbx
    @@pbx
  end
end
