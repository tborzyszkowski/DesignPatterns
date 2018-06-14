package korszun.kacper

class MyPluggableAdapter[A,B,C](a: MyTarget[A,B], b: MyAdaptee[A,C], aTransformer :  (A=>B)=>(C)=>B){
  private var tRequest: A=>B = a.request

  def request: A=>B =  b.getValue _ andThen aTransformer(tRequest)

  def changeRequest(ff : A => B) = {
    tRequest = ff
  }
}
