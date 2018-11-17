# Slow working logger example
class SlowLogger
  attr_accessor :log_name
  @creation ||= Mutex.new

  def initialize(log_name)
    @log_name = log_name
  end

  # This logger works slow because it's lacking double-lock
  def self.instance(log_name = 'log.txt')
    @instance &. log_name = log_name
    @creation.synchronize { @instance ||= SlowLogger.new(log_name) }
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
