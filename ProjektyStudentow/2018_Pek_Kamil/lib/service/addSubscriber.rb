class AddSubscriber
  attr_accessor :service, :number

  def initialize(service, number)
    @service = service
    @number = number    
  end

  def execute
    command = "dodano abonenta o numerze 2021"
    @service.action(command)
  end
end
