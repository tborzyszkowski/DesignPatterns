package korszun.kacper

import korszun.kacper.MasterThesis.MasterThesis
import DocumentThesisAdapter._

object ThesisDocumetAdapter {
  class ThesisAdaptee(a: MasterThesis) extends MyAdaptee[Unit,MasterThesis]{
    override def getValue(b: Unit): MasterThesis = a
  }

  class ThesisDocumetAdapter[A <% Document] (myTarget: MyTarget[Unit,A],
                                             thesisAdaptee: ThesisAdaptee,
                                              ff: (Unit => A) => MasterThesis => A)
    extends MyPluggableAdapter[Unit, A, MasterThesis](myTarget, thesisAdaptee, ff)
}
