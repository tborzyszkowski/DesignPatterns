class PremiumCall
  def initialize(call)
    @call = call
  end

  def increaseCost
    @call.cost = @call.cost + 10
  end

  def calling
    self.increaseCost
    puts("--- POŁĄCZENIE PREMIUM ---")
    @call.calling
  end
end
