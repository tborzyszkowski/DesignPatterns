require 'time'

class LoggerInherit
  @@instance = nil
  @@log = File.open('lib/log.txt', 'a')

  def self.instance
    @@instance ||= LoggerInherit.new
  end

  def self.log
    @@log.puts "#{self.object_id} – #{DateTime.now}"
  end
end

class Registrant < LoggerInherit
end

class Recorder < LoggerInherit
end
