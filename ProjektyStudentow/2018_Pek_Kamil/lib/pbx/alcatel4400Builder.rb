require_relative 'pbx'
require_relative 'pbxBuilder'
class Alcatel4400Builder
  @@pbx = nil

  def initialize
    @@pbx = Pbx.new()
    @@pbx
  end

  def buildModel
    @@pbx.name = "Alcatel 4400"
  end

  def buildBilling
    @@pbx.billing = true
  end

  def buildRecorder
    @@pbx.recorder = false
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
