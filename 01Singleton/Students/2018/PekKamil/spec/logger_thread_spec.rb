require_relative '../lib/singletonThread'

describe LoggerThread, '#instance' do
  context 'singleton' do
    it 'thread' do
      logger1 = LoggerThread
      logger2 = LoggerThread
      expect(logger1.object_id).to eq logger2.object_id
    end
  end
end
