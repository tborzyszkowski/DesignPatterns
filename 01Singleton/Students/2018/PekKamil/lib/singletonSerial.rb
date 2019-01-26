require 'time'

class LoggerSerial
  @@instance = nil
  @@log = File.open('lib/log.txt', 'a')

  def self.instance
    @@instance = LoggerSerial.new
    serialize
  end

  def self.log
    @@log.puts "#{self.object_id} – #{DateTime.now}"
  end

  def self.serialize
    File.write('lib/instance.txt', Marshal.dump(self))
  end

  def self.deserialize
    Marshal.restore(File.read('lib/instance.txt'))
  end
end
