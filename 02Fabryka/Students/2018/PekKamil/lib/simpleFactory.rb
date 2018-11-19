require 'singleton'
require_relative 'factoryMethod'

class SimpleTrainFactory
  include Singleton

  def take_a_ride(type, number)
    case type
    when "Locomotive"
      case number
      when 'OK1' then OK1.new
      when 'OK22' then OK22.new
      when 'OL49' then OL49.new
      when 'TY1' then TY1.new
      when 'TY5' then TY5.new
      end
    when "Railcar"
      case number
      when 'SA133' then SA133.new
      when 'SA136' then SA136.new
      when 'SA139' then SA139.new
      when 'SN82' then SN82.new
      when 'SN84' then SN84.new
      end
    when "Diesel"
      case number
      when 'ST44' then ST44.new
      when 'SU46' then SU46.new
      when 'SM48' then SM48.new
      when 'SM02' then SM02.new
      when 'SM40' then SM40.new
      end
    when "EZT"
      case number
      when 'EN57' then EN57.new
      when 'EW60' then EW60.new
      when 'EN62' then EN62.new
      when 'EN97' then EN97.new
      when 'ED161' then ED161.new
      end
    end
  end
end
