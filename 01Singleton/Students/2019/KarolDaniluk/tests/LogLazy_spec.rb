require_relative '../src/LogLazy'

describe LogLazy do

    describe "log_lazy.txt" do
        it "file doesn't exist before call" do
            expect(File.file?('log_lazy.txt')).to be false
        end

        it "do exist after call" do
            LogLazy.add "test text"
            expect(File.file?('log_lazy.txt')).to be true
        end
    end

    describe "object_id" do
        subject(:object1) {LogLazy.add "testowy tekst z obj1"}
        subject(:object2) {LogLazy.add "testowy tekst z obj2"}
        it "both objects have the same object id" do
            expect(object1.object_id == object2.object_id).to be true
        end
    end
end
