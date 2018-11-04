package korszun.kacper

import scala.collection.mutable.ListBuffer

object MasterThesis {

  object TextElements {
    sealed trait TextElement
    case class TParagraph(text: String) extends TextElement
    case class TImage(src: String) extends TextElement
    case class TTable(tableString:String) extends TextElement
    class TBreak extends TextElement
  }


  private case class Teacher(names: List[String], surnames: List[String])
  private case class Student(names: List[String], surnames: List[String], email: String, indexNumber: String)

  case class TextSubsection(title : String, number : Int, text :List[TextElements.TextElement])

  class TextSection {
    val number: Int = 1
    val title: String = null
    val text: List[TextElements.TextElement] = List()
    val subsections:  List[TextSubsection] = List()
  }

  class Chapter {
    val  number : Int = 1
    val title : String = ""
    val text : List[TextElements.TextElement] = List()
    val sections : List[String] = List()
  }

  class  MasterThesis(student: Student, teacher: Teacher, title: String) {

    private var _introduction : List[TextElements.TextElement] = List()
    def setIntroduction(introduction : List[TextElements.TextElement]) = {_introduction = introduction}
    def getIntroduction= _introduction

    private var _summary: List[TextElements.TextElement] = List()
    def setSummary(summary : List[TextElements.TextElement]) = {_summary = summary}
    def getSummary= _summary

    private val thesisText : ListBuffer[Chapter] = ListBuffer()
    def addChapter(chapter: Chapter) :Unit = {thesisText += chapter}
    def addChapter(title: String, text: List[TextElements.TextElement], sections: List[TextSection]) ={
      thesisText+= new Chapter
    }
    def getChapter(number: Int) = thesisText.find(p => p.number == number)

  }
}
