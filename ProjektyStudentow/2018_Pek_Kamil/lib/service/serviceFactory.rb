require_relative 'service'
class ServiceFactory
  def maintain(type)
    case type
    when 'ssh' then Ssh.new
    end
  end
end

class Ssh < Service
  def initialize
  end
end
