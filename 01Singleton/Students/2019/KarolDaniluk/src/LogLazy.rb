# przykład leniwego singletona

File.delete 'log_lazy.txt' if File.file? 'log_lazy.txt'

class LogLazy
    def self.add text
        @@log = File.new("log_lazy.txt", "a")
        @@log.puts text
    end

    private_class_method :new
end

# l1 = LogLazy.instance # to nie zadziała, nie można wywołać instancji tego obiektu

# l1 = LogLazy.add "Tekst z l1"
# l2 = LogLazy.add "Tekxt z l2"

# puts l1.object_id
# puts l2.object_id

# puts l1.object_id == l2.object_id
