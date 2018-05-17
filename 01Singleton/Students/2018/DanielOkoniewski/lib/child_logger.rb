require_relative 'thread_safe_singleton'
require 'json'

class ChildLogger < Logger
  attr_accessor :log_name, :instancee
  @creation ||= Mutex.new

  def self.instance(log_name = 'inherited.txt')
    @instance &.  log_name = log_name
    @instance ||= @creation.synchronize { @instance ||= ChildLogger.new(log_name) }
  end
end
