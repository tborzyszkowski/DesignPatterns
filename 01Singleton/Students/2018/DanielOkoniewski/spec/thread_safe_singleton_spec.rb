require_relative '../lib/thread_safe_singleton'

describe Logger, '#instance' do
  after(:all) do
    File.delete('./log.txt')
  end

  context 'when used multiple times' do
    it 'is the same instance' do
      logger1 = Logger.instance('log1.txt')
      logger2 = Logger.instance('log2.txt')
      expect(logger1).to equal(logger2)
    end
  end

  context 'with multiple threads running' do
    it 'is thread safe' do
      thread1 = Thread.new { Logger.instance.log_msg("I'm gonna log this!")     }
      thread2 = Thread.new { Logger.instance.log_msg("I'm gonna log this too!") }
      thread1.join
      thread2.join
      instances = ObjectSpace.each_object(Logger) {}
      expect(instances).to eq 1
    end
  end
end

describe Logger, '#serialize' do
  after(:all) do
    File.delete('./logger.json')
  end

  it 'is serialization thread safe' do
    instance = Logger.instance('dasd.txt')
    instance.serialize
    thread1 = Thread.new { Logger.deserialize }
    thread2 = Thread.new { Logger.deserialize }
    thread1.join
    thread2.join
    instances = ObjectSpace.each_object(Logger) {}
    expect(instances).to eq 1
  end
end
