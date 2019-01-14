class Call
  attr_accessor :direction, :caller, :recipient, :cost  

  def prepare(pbx)
    @observers = []
    puts("\n")
    puts("--- Uruchamianie połączenia: #{direction} ---")
    puts("--- Centrala obsługująca połączenie: #{pbx.getModel} ---")
    puts("--- Abonent: #{caller} --- Numer wywoływany: #{recipient} ---")
  end

  def calling
    self.dial
    self.ring
    self.recipAnswer
    self.callerAnswer
    self.recipReply
    self.ending
  end

  def dial
    puts("[C] trwa zestawianie połączenia...")
  end

  def ring
    puts("[C] ring ding ding")
  end

  def recipRing
    puts("[R] ding ring ding")
  end

  def recipAnswer
    puts("[R] HALO, SŁUCHAM!")
  end

  def callerAnswer
    puts("[C] DZWONIĘ DO PANA W BARDZO NIETYPOWEJ SPRAWIE...")
  end

  def recipReply
    puts("[R] DZIĘKUJĘ BARDZO, ALE NIE SKORZYSTAM.")
  end

  def reject
    puts("[R] pip pip pip")
  end

  def ending
    puts("[R] clank")
    puts "--- Koszt połączenia wyniósł: #{cost} ---"
  end

  def attachObserver(observer)
    @observers.push observer
  end

  def detachObserver(observer)
    @observers.remove observer
  end

  def notifyObserver
    @observers.each { |observer| observer.update(self, direction) }
  end
end
