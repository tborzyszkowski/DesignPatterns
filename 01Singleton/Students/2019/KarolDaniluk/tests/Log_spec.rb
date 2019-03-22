require_relative '../src/Log'

describe Log do
    
    describe '.new' do
        it 'should raise error' do
            expect{Log.new}.to raise_error(NameError)
        end
    end

    describe 'instance.object_id' do
        subject(:object1) {Log.instance}
        subject(:object2) {Log.instance}
        it 'both objects should have the same object_id' do
            expect(object1.object_id).to eq (object2.object_id)
        end
    end

    describe '.clone' do
        let(:object) {Log.instance}
        subject {object.clone}
        it 'should return the same instance' do
            expect(subject.object_id).to eq (object.object_id)
        end
    end
    
    describe '.dup' do
        let(:object) {Log.instance}
        subject {object.dup}
        it 'should return the same instance' do
            expect(subject.object_id).to eq (object.object_id)
        end
    end

    describe '.serialize' do
        subject {Log.instance}
        it 'should create log.bin file' do
            subject.serialize
            expect(File.file?('log.bin')).to be true
        end
    end

    describe '.deserialize' do
        let(:object) {Log.instance}
        before {object.serialize}
        subject {Log.deserialize}

        # po deserializacji object_id powinny być takie same
        it '.objet_id of deserialized object should be the same' do
            expect(subject.object_id).to eq object.object_id
        end

        it 'after deserialization content should stay the same' do
            object.add("Text before serialization")
            object.add("Text after serialization")
            expect(subject.read).to eq "Text before serialization\nText after serialization\n"
        end
    end

    describe 'threadsafe' do
        CORES = 1000
        it 'instance.object_id' do
            ids = []
            threads = []
            CORES.times do
                threads << Thread.new {ids << Log.instance.object_id}
            end
            threads.map(& :join)
            expect(ids.uniq.length).to eq 1
        end

        it 'add text' do
            threads = []
            CORES.times do |i|
                threads << Thread.new {Log.instance.add "Thread #{i}"}
            end
            threads.map(& :join)
            expect(true).to be true
        end
    end

end
