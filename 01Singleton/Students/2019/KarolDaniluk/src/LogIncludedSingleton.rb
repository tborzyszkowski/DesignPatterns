# implementacja singletona z wykorzystaniem wbudowanego modułu Singleton

require 'singleton'

File.delete 'log_included.txt' if File.file? 'log_included.txt'

class LogIncludedSingleton
    include Singleton

    def initialize
        @log = File.new('log_included.txt', 'a')
    end

    def add(text)
        @log.puts text
    end

end

# s1 = LogIncludedSingleton.instance()
# s2 = LogIncludedSingleton.instance()

# s3 = Log.new # to zwróci błąd: uninitialized constant Log (NameError)

# puts s1.object_id
# puts s2.object_id

# puts s1.object_id == s2.object_id

# s1.add("Tekst z s1")
# s2.add "Tekst z s2"