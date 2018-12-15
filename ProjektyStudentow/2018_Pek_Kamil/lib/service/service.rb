class Service
  attr_accessor :type, :command

  def prepare(pbx)
    puts("\n")
    puts("--- Przechodzenie do trybu serwisowego centrali #{pbx.getModel} ---")
  end

  def action(command)
    puts("--- Wykonano operację: #{command} ---")
  end
end
