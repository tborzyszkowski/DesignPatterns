package korszun.kacper
import DocumentThesisAdapter._
import MasterThesis._
import ThesisDocumetAdapter._
/*
Zadanie 2
Opracować przykład ilustrujący praktyczne wykorzystanie techniki tworzenia adapterów klas,
 zaprezentowaną w projekcie PluggableAdapter.
 */



object Client extends App {

  class TypeTarget[A](b :A) extends MyTarget[Unit, A] {
    override def request(a: Unit): A = b
  }

  implicit def toAdaptee[A <% Document](a:A) = new DocumentAdaptee[A](a)
  implicit def toAdaptee(a:MasterThesis) = new ThesisAdaptee(a)
  implicit def toTarget(a: MasterThesis) = new TypeTarget[MasterThesis](a)
  implicit def toTarget[A <% Document](a: A) = new TypeTarget[A](a)


  class DocumentTransformator[A <% Document](private var myDocument : A) {
    private var myThesis : MasterThesis = null
    private var adapter1 =  new DocumentThesisAdapter[A] (myThesis, myDocument,
      (fx: (Unit => MasterThesis)) => (str :String) => {
       null
      })

    private var adapter2 = new ThesisDocumetAdapter[A] ( myDocument, myThesis,
      (fx: (Unit => A)) => (m :MasterThesis) => {
        null.asInstanceOf[A]
      })

    def toMasterThesis :MasterThesis = {
      myThesis = adapter1.request({})
      myThesis
    }
    def fromMasterThesis : Unit = {
      myDocument = adapter2.request({})
    }
  }

  override def main(args: Array[String]): Unit = {
    val adapter1 = new DocumentTransformator[MyHtmlDocument](new MyHtmlDocument(""))
    val adapter2 = new DocumentTransformator[MyMdDocument](new MyMdDocument(""))
    val adapter3 = new DocumentTransformator[MyLatexDocument](new MyLatexDocument(""))
    println("hello")
    //new MyLatexDocument("").saveFile("heyho")
  }
}


/*implicit def toAdapter(a: MyHtmlDocument) = new HtmlThesisAdapter(a)
 implicit def toAdapter(a: MyLatexDocument) = new LatexThesisAdapter(a)
 implicit def toAdapter(a: MyMdDocument) = new MdThesisAdapter(a)
 */

/*
  val adapter1 = new Adapter(new Adaptee())
    println(adapter1.RequestF(5))

    val adapter2 = new Adapter(new Target())
    println(adapter2.RequestF(5))

    adapter2.ChangeRequest(i => s"${2*i} -- nowy wynik")
    println(adapter2.RequestF(5))
 */

