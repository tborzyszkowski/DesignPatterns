# Base interface for commands
class Command
  def self.execute(_subject)
    raise NotImplementedError
  end
end

class StartPC < Command
  def self.execute(subject)
    subject.turn_on
  end
end

class ShutdownPC < Command
  def self.execute(subject)
    subject.turn_off
  end
end

class RestartPC < Command
  def self.execute(subject)
    subject.restart
  end
end

class HibernatePC < Command
  def self.execute(subject)
    subject.hibernate
  end
end

# Commands available for computer, hidden from client via module
module ComputerCommands
  def turn_on
    self.state = if state == 'Hibernated'
                   Memento.mementos[id][:memento].state
                 else
                   'on'
                 end
  end

  def turn_off
    self.state = 'off'
  end

  def restart
    turn_off
    turn_on
    self.state = 'on (restarted)'
  end

  def hibernate
    Memento.mementos[id] = { memento: Memento.new(@state) }
    self.state = 'Hibernated'
  end
end
