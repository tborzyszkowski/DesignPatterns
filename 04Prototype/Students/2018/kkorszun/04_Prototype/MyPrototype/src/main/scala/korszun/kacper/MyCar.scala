package korszun.kacper

import java.io.{ByteArrayInputStream, ByteArrayOutputStream, ObjectInputStream, ObjectOutputStream}


class MyCar(id: String, brand: CarBrand.BrandValue, private var engine: CarEngine, private var modelName: String) extends MyBetterPrototype(id) {
  //private var modelName = modelName

  override def clone(): AnyRef = super.clone()
  override def getId: String = id
  def setModelName(newName:String) = {this.modelName = newName}
  def getModelName = this.modelName
  def setEngine(carEngine: CarEngine) = {engine = carEngine}
  def getEngine=engine
  override def deepCopy = {
    val stream: ByteArrayOutputStream = new ByteArrayOutputStream()
    val oos = new ObjectOutputStream(stream)
    oos.writeObject(this)
    oos.close
    val ois = new ObjectInputStream(new ByteArrayInputStream(stream.toByteArray))
    val value = ois.readObject
    ois.close
    value.asInstanceOf[MyCar]
  }
}
