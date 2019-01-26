require_relative '../lib/singletonThread'
require_relative '../lib/singletonSerial'
require_relative '../lib/singletonInherit'
require 'benchmark'

serial = Benchmark.realtime do
  threads = []
  1000.times do
    threads << Thread.new { LoggerSerial.instance }
  end
  threads.map(&:join)
end

thread = Benchmark.realtime do
  threads = []
  1000.times do
    threads << Thread.new { LoggerThread.instance }
  end
  threads.map(&:join)
end

inherit = Benchmark.realtime do
  threads = []
  1000.times do
    threads << Thread.new { LoggerInherit.instance }
  end
  threads.map(&:join)
end

puts "Czas LoggerSerial: #{serial}"
puts "Czas LoggerThread: #{thread}"
puts "Czas LoggerInherit: #{inherit}"
