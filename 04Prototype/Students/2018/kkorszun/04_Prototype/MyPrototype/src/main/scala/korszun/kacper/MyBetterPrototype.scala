package korszun.kacper


@SerialVersionUID(100L)
abstract class MyBetterPrototype(id: String) extends Serializable with Cloneable {
  override def clone(): AnyRef = super.clone()

  def getId : String
  def shallowCopy = this.clone().asInstanceOf[MyCar]
  def deepCopy : MyBetterPrototype
}
