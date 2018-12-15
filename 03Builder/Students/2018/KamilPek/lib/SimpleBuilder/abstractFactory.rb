require 'singleton'
require_relative 'factoryMethod'

class AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    raise NotImplementedError
  end
end

class OK1Factory < AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    OK1.new
  end
end

class OK22Factory < AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    OK22.new
  end
end

class OL49Factory < AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    OL49.new
  end
end

class TY1Factory < AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    TY1.new
  end
end

class TY5Factory < AbstractLocomotiveFactory
  include Singleton
  def take_a_ride
    TY5.new
  end
end

class AbstractRailcarFactory
  include Singleton
  def take_a_ride
    raise NotImplementedError
  end
end

class SA133Factory < AbstractRailcarFactory
  include Singleton
  def take_a_ride
    SA133.new
  end
end

class SA136Factory < AbstractRailcarFactory
  include Singleton
  def take_a_ride
    SA136.new
  end
end

class SA139Factory < AbstractRailcarFactory
  include Singleton
  def take_a_ride
    SA139.new
  end
end

class SN82Factory < AbstractRailcarFactory
  include Singleton
  def take_a_ride
    SN82.new
  end
end

class SN84Factory < AbstractRailcarFactory
  include Singleton
  def take_a_ride
    SN84.new
  end
end

class AbstractDieselFactory
  include Singleton
  def take_a_ride
    raise NotImplementedError
  end
end

class ST44Factory < AbstractDieselFactory
  include Singleton
  def take_a_ride
    ST44.new
  end
end

class SU46Factory < AbstractDieselFactory
  include Singleton
  def take_a_ride
    SU46.new
  end
end

class SM48Factory < AbstractDieselFactory
  include Singleton
  def take_a_ride
    SM48.new
  end
end

class SM02Factory < AbstractDieselFactory
  include Singleton
  def take_a_ride
    SM02.new
  end
end

class SM40Factory < AbstractDieselFactory
  include Singleton
  def take_a_ride
    SM40.new
  end
end

class AbstractEZTFactory
  include Singleton
  def take_a_ride
    raise NotImplementedError
  end
end

class EN57Factory < AbstractEZTFactory
  include Singleton
  def take_a_ride
    EN57.new
  end
end

class EW60Factory < AbstractEZTFactory
  include Singleton
  def take_a_ride
    EW60.new
  end
end

class EN62Factory < AbstractEZTFactory
  include Singleton
  def take_a_ride
    EN62.new
  end
end

class EN97Factory < AbstractEZTFactory
  include Singleton
  def take_a_ride
    EN97.new
  end
end

class ED161Factory < AbstractEZTFactory
  include Singleton
  def take_a_ride
    ED161.new
  end
end
