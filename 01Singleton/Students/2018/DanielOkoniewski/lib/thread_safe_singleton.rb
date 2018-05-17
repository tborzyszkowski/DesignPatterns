require 'json'

# Simple singleton logger example
class Logger
  attr_accessor :log_name
  @creation ||= Mutex.new

  def initialize(log_name)
    @log_name = log_name
  end

  def self.instance(log_name = 'log.txt')
    @instance &.  log_name = log_name
    @instance ||= @creation.synchronize { @instance ||= Logger.new(log_name) }
  end

  def log_msg(message)
    log = File.open(@log_name.to_s, 'a')
    log.puts(message)
  end

  def serialize
    File.write('logger.json', { 'log_name' => @log_name }.to_json)
  end

  def self.deserialize
    data = JSON.parse File.read('logger.json')
    instance(data['log_name'])
  end
end
