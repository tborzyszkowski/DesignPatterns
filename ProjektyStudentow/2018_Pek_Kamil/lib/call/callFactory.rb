require_relative 'call'
class CallFactory
  def make_call(type, caller, recipient)
    case type
    when 'internal' then InternalCall.new("WEWNĘTRZNE", caller, recipient)
    when 'outgoing' then OutgoingCall.new("WYCHODZĄCE", caller, recipient)
    when 'incoming' then IncomingCall.new("PRZYCHODZĄCE", caller, recipient)
    end
  end
end

class InternalCall < Call
  def initialize(type, caller, recipient)
    self.direction = type
    self.caller = caller
    self.recipient = recipient
    self.cost = 0
  end

  def calling
    self.dial
    self.ring
    self.reject
  end
end

class OutgoingCall < Call
  def initialize(type, caller, recipient)
    self.direction = type
    self.caller = caller
    self.recipient = recipient
    self.cost = 5
  end
end

class IncomingCall < Call
  def initialize(type, caller, recipient)
    self.direction = type
    self.caller = caller
    self.recipient = recipient
    self.cost = 0
  end

  def calling
    self.recipRing
    self.recipAnswer
    self.callerAnswer
    self.reject
  end
end
