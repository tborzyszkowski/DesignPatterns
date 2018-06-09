require_relative 'computer'
require 'singleton'

class FlyweightComponentsFactory
  include Singleton
  attr_reader :registered, :created

  def initialize
    @registered = {}
    @created    = {}
  end

  def register(reference_name, class_name, params = [])
    @registered[reference_name] = { class_name: class_name, params: [params].flatten }
  end

  def create(reference_name)
    if @created.key?(reference_name)
      object = @created[reference_name]
    else
      h = @registered[reference_name]
      object = h[:class_name].new(*(h[:params]))
      @created[reference_name] = object
    end
    object
  end
end
