package korszun.kacper

import scala.collection.mutable

object ParkingSpotGenerator {
  val PARKING_SPOTS_NUMBER = 120
  var currIndex: Int = 0
  var reservedSpots: mutable.MutableList[Int] = mutable.MutableList()

  def getSpot : Option[Int] = {
    if(reservedSpots.length >= 120) {
      None
    } else if(currIndex < 120) {
      currIndex += 1
      reservedSpots += currIndex
      Some(currIndex)
    } else {
      var potential_spot = 1
      while(reservedSpots.contains(potential_spot)) potential_spot +=1
      Some(potential_spot)
    }
  }

}
