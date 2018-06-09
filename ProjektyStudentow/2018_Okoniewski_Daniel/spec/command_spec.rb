require_relative '../lib/command'
require_relative '../lib/computer'

describe StartPC, '#execute' do
  context 'when passed a computer' do
    it 'starts the computer' do
      computer = Computer.new
      computer.execute(StartPC)
      expect(computer.state).to eq('on')
    end

    it 'starts from hibernation properly' do
      computer = Computer.new
      computer.id = 1
      computer.state = 'Before hibernation'
      computer.execute(HibernatePC)
      computer.execute(StartPC)
      expect(computer.state).to eq('Before hibernation')
    end
  end
end

describe ShutdownPC, '#execute' do
  context 'when passed a computer' do
    it 'shuts down the computer' do
      computer = Computer.new
      computer.execute(ShutdownPC)
      expect(computer.state).to eq('off')
    end
  end
end

describe RestartPC, '#execute' do
  context 'when passed a computer' do
    it 'restarts the computer' do
      computer = Computer.new
      computer.execute(RestartPC)
      expect(computer.state).to eq('on (restarted)')
    end
  end
end

describe HibernatePC, '#execute' do
  context 'when passed a computer' do
    it 'hibernates the computer' do
      computer = Computer.new
      computer.execute(HibernatePC)
      expect(computer.state).to eq('Hibernated')
    end

    it 'preserves the state' do
      computer = Computer.new
      computer.id = 1
      computer.state = 'preserved state'
      computer.execute(HibernatePC)
      expect(Memento.mementos[1][:memento].state).to eq('preserved state')
    end
  end
end
