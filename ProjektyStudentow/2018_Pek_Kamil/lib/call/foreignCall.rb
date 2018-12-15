class ForeignCall
  def initialize(adapter)
    @adapter = adapter
  end

  def zvonit
    puts("--- POŁĄCZENIE ZAGRANICZNE ---")
    @adapter.calling
  end
end
