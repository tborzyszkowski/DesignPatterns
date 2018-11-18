require_relative '../lib/singletonInherit'

describe LoggerInherit, '#instance' do
  context 'singleton' do
    it 'heritance_1' do
      reg1 = Registrant
      reg2 = Registrant
      expect(reg1.object_id).to eq reg2.object_id
    end
    it 'heritance_2' do
      rec1 = Recorder
      rec2 = Recorder
      expect(rec1.object_id).to eq rec2.object_id
    end
  end
end
