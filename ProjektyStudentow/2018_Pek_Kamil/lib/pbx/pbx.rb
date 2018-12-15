class Pbx
  attr_accessor :name, :billing, :recorder, :service
  @@configuration = Hash.new

  def show
    puts("--- Centrala telefoniczna ---")
    puts("Model centrali:\t #{name}")
    puts("Billinigi:\t#{billing}")
    puts("Nagrywarka:\t#{recorder}")
    puts("Konfiguracja:\t#{service}")
    puts("-----------------------------")
  end

  def showShort
    puts("--- Uruchomiono centralę telefoniczną: #{name} [#{self.object_id}] ---")
  end

  def getModel
    "#{name} [#{self.object_id}]"
  end
end
