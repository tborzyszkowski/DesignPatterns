require_relative '../lib/computer_builder'

describe ComputerBuilder, '#build' do
  context 'when building a computer' do
    subject { ComputerBuilder.instance.build }
    it 'creates computer' do
      instances1 = ObjectSpace.each_object(Computer) {}
      subject.finish
      instances2 = ObjectSpace.each_object(Computer) {}
      expect(instances2 - instances1).to eq 1
    end

    it 'inserts ram' do
      FlyweightComponentsFactory.instance.register('Hyperx Fury', Ram, [4096, 'HyperX Fury', 'Kingston'])
      expect(subject.insert_ram('Hyperx Fury').finish.ram.name).to eq('HyperX Fury')
    end

    it 'sets cpu' do
      FlyweightComponentsFactory.instance.register('Intel Core i3-7100', Cpu, [3900, 'i3-7100', 'Intel'])
      expect(subject.insert_cpu('Intel Core i3-7100').finish.cpu.name).to eq('i3-7100')
    end

    it 'sets gpu' do
      FlyweightComponentsFactory.instance.register('Radeon', Gpu, [4096, 8000, 'Radeon', 'AMD'])
      expect(subject.insert_gpu('Radeon').finish.gpu.name).to eq('Radeon')
    end

    it 'sets drive' do
      FlyweightComponentsFactory.instance.register('GOODRAM CX300', Drive, [120, 'CX300', 'GOODRAM'])
      expect(subject.insert_drive('GOODRAM CX300').finish.drive.name).to eq('CX300')
    end
  end
end
