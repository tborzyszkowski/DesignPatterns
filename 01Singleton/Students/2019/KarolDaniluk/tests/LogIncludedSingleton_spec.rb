require_relative '../src/LogIncludedSingleton'

describe LogIncludedSingleton do
    subject(:object1) {LogIncludedSingleton.instance}
    subject(:object2) {LogIncludedSingleton.instance}

    describe '#object_id' do
        it 'both objects have the same object id' do
            expect(object1.object_id == object2.object_id).to be true
        end
    end
end
