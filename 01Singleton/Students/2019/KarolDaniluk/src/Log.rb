# implementacja singletona: główny plik
# jest to implementacja zachłanna: instancja jest tworzona podczas ładowania klasy, nawet jeżeli nie jest użyta

require 'monitor' # umożliwia odporność na współbieżne wykorzystane

class Log

    @@concurrent = Monitor.new

    LOGFILE = 'log.txt' # plik log
    BINFILE = 'log.bin' # plik log po serializacji
    private_constant :LOGFILE, :BINFILE

    def self.delete
        File.delete LOGFILE if File.file? LOGFILE
    end

    def initialize
        Log.delete  # na potrzeby testów usuwamy plik log jeżeli istenieje
        @log = File.new(LOGFILE, 'w+')
    end
    
    @@instance = Log.new        # tworzenie jedynej instancji
    private_class_method :new   # zablokowanie możliwości stworzenia innej instancji
    private_class_method :clone   # zablokowanie możliwości stworzenia innej instancji
    
    def add(text)
        @@concurrent.synchronize do
            @log.puts text
        end
    end
    
    def read()
        @@concurrent.synchronize do
            @log.close
            ans = IO.read(LOGFILE) # wersja dla Windows
            @log = File.open(@log, 'a+')
            ans
        end
    end

    def self.instance
        @@concurrent.synchronize do
            @@instance
        end
    end

    def serialize
        @@concurrent.synchronize do
            File.open(BINFILE, 'wb') {|f| f.write(Marshal.dump(LOGFILE))}
        end
    end
    
    def self.deserialize
        @@concurrent.synchronize do
            @log = Marshal.load(File.binread(BINFILE))
        end
        instance
    end

    def clone
        @@instance
    end

    def dup
        @@instance
    end
end

# z1 = Log.instance
# c1 = z1.clone
# d1 = z1.dup

# puts z1.object_id
# puts c1.object_id
# puts d1.object_id
# z2 = Log.instance

# puts z1.object_id
# puts z2.object_id

# z1.add('Tekst z z1')
# z2.serialize

# z3 = Log.deserialize
# puts z3.read
# puts z3.object_id