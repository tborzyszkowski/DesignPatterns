package korszun.kacper

import java.text.SimpleDateFormat
import java.util.Date


// Object used by Coupe and Hatchback, but not Van

object DealerCarIdGeneretor {
  val START_NUMBER = 56789
  var counter = 0

  def getId()  = {
    counter += 2
    "di_"+(new SimpleDateFormat("dd_MM_yyyy").format(new Date()))+"_"+(START_NUMBER+counter)
  }
}
