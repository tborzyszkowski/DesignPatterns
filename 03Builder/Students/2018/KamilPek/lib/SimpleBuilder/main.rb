require_relative 'eztBuilder'
require_relative 'dieselBuilder'
class Main
  def main
    puts "Factory Method"
    dart_start = Time.now.to_f
    dart = EztBuilder.new
    dart.build
    puts "Czas tworzenia: " + (Time.now.to_f - dart_start).to_s

    puts "Abstract Factory"
    gagarin_start = Time.now.to_f
    gagarin = DieselBuilder.new
    gagarin.build
    puts "Czas tworzenia: " + (Time.now.to_f - gagarin_start).to_s
  end
end

main = Main.new
main.main
