class Train
  @@parts = Hash.new
  @@trainType = ""

  def initialize(type)
    @@trainType = type
  end

  def []=(*args)
    @@parts[args[0]] = args[1]
  end

  def show
    puts("Typ pociągu:\t#{@@trainType}")
    puts("Model:\t\t#{@@parts["model"]}")
    puts("Silnik:\t\t#{@@parts["engine"]}")
    puts("Siedzienia:\t#{@@parts["seats"]}")
    puts("Darmowe WiFi:\t#{@@parts["wifi"]}")
  end
end
