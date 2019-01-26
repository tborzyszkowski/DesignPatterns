package korszun.kacper

import DocumentThesisAdapter._

class MyLatexDocument (value: String) extends  Document {
  override def toString = value
  def saveFile(filename:String) = {
    import java.io._
    val pw = new PrintWriter(new File(s"${filename}.tex" ))
    pw.write("% !TeX spellcheck = pl_PL\n\\documentclass[openright]{xmgr}")
    pw.close
  }
}
