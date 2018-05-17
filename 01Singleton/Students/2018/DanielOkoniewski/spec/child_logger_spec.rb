require_relative '../lib/child_logger'

describe ChildLogger, '#instance' do
  after(:all) do
    File.delete('./log.txt')
    File.delete('./inherited.txt')
  end

  context 'when being inherited' do
    it 'can create subclass instance' do
      ChildLogger.instance.log_msg("I'm a child!")
      instances = ObjectSpace.each_object(ChildLogger) {}
      expect(instances).to eq 1
    end

    it 'makes sure 1 instance of each class can exist' do
      2.times { ChildLogger.instance.log_msg("I'm a child!") }
      2.times { Logger.instance.log_msg("I'm a superclass!") }
      instances = ObjectSpace.each_object(Logger) {}
      expect(instances).to eq 2
    end

    context 'subclass also' do
      it 'can have 1 instance' do
        logger1 = ChildLogger.instance('log1.txt')
        logger2 = ChildLogger.instance('log2.txt')
        expect(logger1).to equal(logger2)
      end

      it 'is thread safe' do
        thread1 = Thread.new { ChildLogger.instance.log_msg("I'm gonna log this!")     }
        thread2 = Thread.new { ChildLogger.instance.log_msg("I'm gonna log this too!") }
        thread1.join
        thread2.join
        instances = ObjectSpace.each_object(ChildLogger) {}
        expect(instances).to eq 1
      end
    end
  end
end
