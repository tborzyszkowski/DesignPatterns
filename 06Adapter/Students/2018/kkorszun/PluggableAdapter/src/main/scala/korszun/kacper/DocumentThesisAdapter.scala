package korszun.kacper

import MasterThesis._

object DocumentThesisAdapter {
  trait Document
  class DocumentAdaptee[A <% Document](a: A) extends MyAdaptee[Unit,String]{
    override def getValue(b: Unit): String = a.toString
  }
  class DocumentThesisAdapter[A <% Document] (myTarget: MyTarget[Unit,MasterThesis],
                                            documentAdaptee: DocumentAdaptee[A],
                                            ff: (Unit => MasterThesis) => String => MasterThesis)
    extends MyPluggableAdapter[Unit, MasterThesis, String](myTarget, documentAdaptee, ff)
}
