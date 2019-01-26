require_relative '../lib/call/callFactory'

describe Call, '#make_call' do
  context 'when make call' do
    it 'delegates properly' do
      expect(CallFactory.new.make_call('internal', '0202', '0201').class).to be(InternalCall)
    end

    it 'delegates properly' do
      expect(CallFactory.new.make_call('outgoing', '0202', '0201').class).to be(OutgoingCall)
    end

    it 'delegates properly' do
      expect(CallFactory.new.make_call('incoming', '0202', '0201').class).to be(IncomingCall)
    end
  end
end
