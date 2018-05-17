require_relative '../lib/person_builder'

describe PersonBuilder, '#instance' do
  context 'Using PersonBuilder' do
    it 'raises error: abstract method called' do
      expect { PersonBuilder.new.build }.to raise_error
    end
  end

  context 'Using TeacherBuilder' do
    it 'creates teacher' do
      instances = ObjectSpace.each_object(Person) {}
      TeacherBuilder.new.build
      instances2 = ObjectSpace.each_object(Person) {}
      expect(instances2 - instances).to eq 1
    end

    it 'initializes name properly' do
      person = TeacherBuilder.new.build.set_name('John').get
      expect(person.name).to eq('John')
    end

    it 'initializes status properly' do
      person = TeacherBuilder.new.build.status.get
      expect(person.status).to eq('Faculty')
    end

    it 'initializes salary properly' do
      person = TeacherBuilder.new.build.salary.get
      expect(person.salary).to eq 4000
    end
  end

  context 'Using StudentBuilder' do
    it 'creates student' do
      instances = ObjectSpace.each_object(Person) {}
      StudentBuilder.new.build
      instances2 = ObjectSpace.each_object(Person) {}
      expect(instances2 - instances).to eq 1
    end

    it 'initializes name properly' do
      person = StudentBuilder.new.build.set_name('John').get
      expect(person.name).to eq('John')
    end

    it 'initializes status properly' do
      person = StudentBuilder.new.build.status.get
      expect(person.status).to eq('Student')
    end

    it 'initializes salary properly' do
      person = StudentBuilder.new.build.salary.get
      expect(person.salary).to eq 0
    end
  end

  context 'Using EmployeeBuilder' do
    it 'creates employee' do
      instances = ObjectSpace.each_object(Person) {}
      EmployeeBuilder.new.build
      instances2 = ObjectSpace.each_object(Person) {}
      expect(instances2 - instances).to eq 1
    end

    it 'initializes name properly' do
      person = EmployeeBuilder.new.build.set_name('John').get
      expect(person.name).to eq('John')
    end

    it 'initializes status properly' do
      person = EmployeeBuilder.new.build.status.get
      expect(person.status).to eq('Administration')
    end

    it 'initializes salary properly' do
      person = EmployeeBuilder.new.build.salary.get
      expect(person.salary).to eq 3500
    end
  end
end
