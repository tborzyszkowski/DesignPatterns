package korszun.kacper

abstract class MySimplePrototype(id: String) extends scala.Cloneable {
  def getId : String
  override def clone(): AnyRef = super.clone()
}
