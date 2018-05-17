require_relative '../lib/slow_logger'
require_relative '../lib/thread_safe_singleton'
require 'benchmark'

fast = Benchmark.realtime do
  threads = []
  10_000.times do
    threads << Thread.new { Logger.instance }
  end
  threads.map(&:join)
end

slow = Benchmark.realtime do
  threads = []
  10_000.times do
    threads << Thread.new { SlowLogger.instance }
  end
  threads.map(&:join)
end

p 'Fast logger with double-lock'
p fast
p 'Slow logger w/o double-lock'
p slow
