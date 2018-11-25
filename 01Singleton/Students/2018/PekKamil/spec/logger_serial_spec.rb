require_relative '../lib/singletonSerial'

describe LoggerSerial, '#instance' do
  context 'singleton' do
    it 'serialization' do
      logger = LoggerSerial
      deserialize = logger.deserialize
      expect(logger.object_id).to eq deserialize.object_id
    end
  end
end
