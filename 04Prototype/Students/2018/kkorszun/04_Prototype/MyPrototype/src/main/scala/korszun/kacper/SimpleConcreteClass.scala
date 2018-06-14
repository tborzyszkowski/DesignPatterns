package korszun.kacper


class SimpleConcreteClass(id: String, v1: Int, v2 : Double) extends MySimplePrototype(id)  {
  private val m_id = id
  private var v11 = v1
  private val v22 = v2
  var v33 = new StupidClass()
  def printState = println("id: "+id+", v1: "+v11+", v2: "+v22)
  def setV1(nv1: Int) = {v11 = nv1}
  override def getId: String = m_id
  override def clone(): AnyRef = super.clone()
}
