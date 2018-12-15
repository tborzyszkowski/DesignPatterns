require_relative 'pbxBuilder'
class Director
  @@pbxBuilder = nil

  def pbx(pbxBuilder)
    @@pbxBuilder = pbxBuilder
  end

  def build
    @@pbxBuilder.buildModel
    @@pbxBuilder.buildBilling
    @@pbxBuilder.buildRecorder
    @@pbxBuilder.buildService
    @@pbxBuilder.showShort
    # @@pbxBuilder.show
  end
end
