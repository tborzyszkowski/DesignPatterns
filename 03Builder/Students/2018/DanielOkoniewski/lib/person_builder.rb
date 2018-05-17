class Person
  attr_accessor :name, :status, :salary
end

class PersonBuilder
  attr_accessor :person

  def get
    raise NotImplementedError
  end

  def build
    raise NotImplementedError
  end

  def set_name(_name)
    raise NotImplementedError
  end

  def status
    raise NotImplementedError
  end

  def salary
    raise NotImplementedError
  end
end

class TeacherBuilder < PersonBuilder
  def build
    @person = Person.new
    self
  end

  def get
    @person
  end

  def set_name(name)
    @person.name = name
    self
  end

  def status
    @person.status = 'Faculty'
    self
  end

  def salary
    @person.salary = 4000
    self
  end
end

class EmployeeBuilder < PersonBuilder
  def build
    @person = Person.new
    self
  end

  def get
    @person
  end

  def set_name(name)
    @person.name = name
    self
  end

  def status
    @person.status = 'Administration'
    self
  end

  def salary
    @person.salary = 3500
    self
  end
end

class StudentBuilder < PersonBuilder
  def build
    @person = Person.new
    self
  end

  def get
    @person
  end

  def set_name(name)
    @person.name = name
    self
  end

  def status
    @person.status = 'Student'
    self
  end

  def salary
    @person.salary = 0
    self
  end
end
