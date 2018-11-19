require 'time'

class LoggerThread
  @@instance = nil
  @@mutex ||= Mutex.new
  @@log = File.open('lib/log.txt', 'a')

  def self.instance
    @@mutex.synchronize { @instance ||= LoggerThread.new() }
  end

  def self.log
    @@log.puts "#{self.object_id} – #{DateTime.now}"
  end
end
