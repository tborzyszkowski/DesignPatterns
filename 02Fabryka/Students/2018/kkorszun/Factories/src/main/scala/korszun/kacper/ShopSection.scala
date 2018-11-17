package korszun.kacper

object  ShopSection {
  sealed  trait SectionValue
  case object FROZEN_FOOD extends  SectionValue
  case object FRUITS_AND_VEGS extends SectionValue
  case object TEA_AND_COFFEE extends SectionValue
  case object SOFT_DRINKS extends SectionValue
  case object BOOKSTORE extends SectionValue
  case object MOUTH_HYGIENE extends SectionValue
  case object BODY_CLEANING extends SectionValue
  val shopSections = Seq(FROZEN_FOOD, FRUITS_AND_VEGS, SOFT_DRINKS, BOOKSTORE, MOUTH_HYGIENE, BODY_CLEANING, TEA_AND_COFFEE)
}

