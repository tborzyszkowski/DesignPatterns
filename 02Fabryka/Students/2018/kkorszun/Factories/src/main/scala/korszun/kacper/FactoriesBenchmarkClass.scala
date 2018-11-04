package korszun.kacper

import java.util.concurrent.TimeUnit

import org.openjdk.jmh.annotations._


@OutputTimeUnit(TimeUnit.MILLISECONDS)
@BenchmarkMode(Array(Mode.Throughput))
class FactoriesBenchmarkClass {

  @Benchmark
  def sortArr = getArrValues.sorted

  def getArrValues = {
    Array.fill(1000000)(scala.util.Random.nextInt(500) +12)
  }
}
