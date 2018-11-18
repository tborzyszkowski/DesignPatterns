class Train
  attr_accessor :name

  def ride(type)
    case type
    when 'Locomotive' then Locomotive.new
    when 'Railcar' then Railcar.new
    when 'Diesel' then Diesel.new
    when 'EZT' then EZT.new
    end
  end
end

class Locomotive < Train
  def model(number)
    case number
    when 'OK1' then OK1.new
    when 'OK22' then OK22.new
    when 'OL49' then OL49.new
    when 'TY1' then TY1.new
    when 'TY5' then TY5.new
    end
  end
end

class OK1 < Locomotive
  def initialize
    @name = 'Henschel P8'
  end
end

class OK22 < Locomotive
  def initialize
    @name = 'Fablok Chrzanów OK22'
  end
end

class OL49 < Locomotive
  def initialize
    @name = 'Fablok Chrzanów OL49'
  end
end

class TY1 < Locomotive
  def initialize
    @name = 'Linke–Hofmann G12'
  end
end

class TY5 < Locomotive
  def initialize
    @name = 'Henschel Schwartzkopff'
  end
end

class Railcar < Train
  def model(number)
    case number
    when 'SA133' then SA133.new
    when 'SA136' then SA136.new
    when 'SA139' then SA139.new
    when 'SN82' then SN82.new
    when 'SN84' then SN84.new
    end
  end
end

class SA133 < Railcar
  def initialize
    @name = "Pesa 218M"
  end
end

class SA136 < Railcar
  def initialize
    @name = "Pesa Atribo"
  end
end

class SA139 < Railcar
  def initialize
    @name = "Pesa Link"
  end
end

class SN82 < Railcar
  def initialize
    @name = "Duwag Wadloper"
  end
end

class SN84 < Railcar
  def initialize
    @name = "Baureihe 614"
  end
end

class Diesel < Train
  def model(number)
    case number
    when 'ST44' then ST44.new
    when 'SU46' then SU46.new
    when 'SM48' then SM48.new
    when 'SM02' then SM02.new
    when 'SM40' then SM40.new
    end
  end
end

class ST44 < Diesel
  def initialize
    @name = "ŁTZ M62"
  end
end

class SU46 < Diesel
  def initialize
    @name = "HCP 303D"
  end
end

class SM48 < Diesel
  def initialize
    @name = "BMZ/ŁTZ TEM2"
  end
end

class SM02 < Diesel
  def initialize
    @name = "Fablok Ls40"
  end
end

class SM40 < Diesel
  def initialize
    @name = "Mavag DVM 2"
  end
end

class EZT < Train
  def model(number)
    case number
    when 'EN57' then EN57.new
    when 'EW60' then EW60.new
    when 'EN62' then EN62.new
    when 'EN97' then EN97.new
    when 'ED161' then ED161.new
    end
  end
end

class EN57 < EZT
  def initialize
    @name = "Pafawag 5B/6B"
  end
end

class EW60 < EZT
  def initialize
    @name = "Pafawag 6WE"
  end
end

class EN62 < EZT
  def initialize
    @name = "Pesa Elf"
  end
end

class EN97 < EZT
  def initialize
    @name = "Pesa 33WE"
  end
end

class ED161 < EZT
  def initialize
    @name = "Pesa Dart"
  end
end
