package korszun.kacper

class MyDiploma(private var _schoolName: String, _yearOfGraduation: Int) extends Serializable {
  def schoolName = _schoolName
  def schoolName_(string: String) = {_schoolName = string}
  def yearOfGraduation = _yearOfGraduation
}
