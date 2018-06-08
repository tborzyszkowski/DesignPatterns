require_relative '../lib/flyweight_components_factory'

describe FlyweightComponentsFactory, '#register' do
  context 'registering a component' do
    subject { FlyweightComponentsFactory.instance }

    it 'registers a cpu component' do
      subject.register('Intel Core i3-7100', Cpu, [3900, 'i3-7100', 'Intel'])
      expect(subject.registered).to have_key('Intel Core i3-7100')
    end

    it 'registers a drive component' do
      subject.register('GOODRAM CX300', Drive, [120, 'CX300', 'GOODRAM'])
      expect(subject.registered).to have_key('GOODRAM CX300')
    end

    it 'registers a gpu component' do
      subject.register('Radeon', Gpu, [4096, 8000, 'Radeon', 'AMD'])
      expect(subject.registered).to have_key('Radeon')
    end

    it 'registers a ram component' do
      subject.register('Hyperx Fury', Ram, [4096, 'HyperX Fury', 'Kingston'])
      expect(subject.registered).to have_key('Hyperx Fury')
    end
  end
end

describe FlyweightComponentsFactory, '#create' do
  subject { FlyweightComponentsFactory.instance }

  context "when component hasn't been created before" do
    it 'creates a cpu component' do
      subject.register('Intel Core i3-7100', Cpu, [3900, 'i3-7100', 'Intel'])
      expect(subject.create('Intel Core i3-7100').class).to eq(Cpu)
    end

    it 'creates a drive component' do
      subject.register('GOODRAM CX300', Drive, [120, 'CX300', 'GOODRAM'])
      expect(subject.create('GOODRAM CX300').class).to eq(Drive)
    end

    it 'creates a gpu component' do
      subject.register('Radeon', Gpu, [4096, 8000, 'Radeon', 'AMD'])
      expect(subject.create('Radeon').class).to eq(Gpu)
    end

    it 'creates a ram component' do
      subject.register('Hyperx Fury', Ram, [4096, 'HyperX Fury', 'Kingston'])
      expect(subject.create('Hyperx Fury').class).to eq(Ram)
    end
  end

  context 'when componen has been created before' do
    it 'references the cpu component' do
      subject.register('Intel', Cpu, [3900, 'i3-7100', 'Intel'])
      instances1 = ObjectSpace.each_object(Cpu) {}
      2.times { subject.create('Intel') }
      instances2 = ObjectSpace.each_object(Cpu) {}
      expect(instances2 - instances1).to eq 1
    end

    it 'references the drive component' do
      subject.register('GOODRAM', Drive, [120, 'CX300', 'GOODRAM'])
      instances1 = ObjectSpace.each_object(Drive) {}
      2.times { subject.create('GOODRAM') }
      instances2 = ObjectSpace.each_object(Drive) {}
      expect(instances2 - instances1).to eq 1
    end

    it 'references the gpu component' do
      subject.register('GeForce', Gpu, [4096, 8000, 'GeForce', 'Nvidia'])
      instances1 = ObjectSpace.each_object(Gpu) {}
      2.times { subject.create('GeForce') }
      instances2 = ObjectSpace.each_object(Gpu) {}
      expect(instances2 - instances1).to eq 1
    end

    it 'references the ram component' do
      subject.register('Hyperx', Ram, [4096, 'HyperX Fury', 'Kingston'])
      instances1 = ObjectSpace.each_object(Ram) {}
      2.times { subject.create('Hyperx') }
      instances2 = ObjectSpace.each_object(Ram) {}
      expect(instances2 - instances1).to eq 1
    end
  end
end
