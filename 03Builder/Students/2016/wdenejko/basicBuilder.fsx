open System.Collections.Generic
type Product() =
    let mutableValue = new List<string>()
    let privateAddToSeed input = 
        mutableValue.Add(input)
    member this.Add x = 
        privateAddToSeed x
    member this.Show () =
        mutableValue |> Seq.iteri (fun index item -> printfn "%s" mutableValue.[index])

[<AbstractClass>]
type Builder() =
    abstract member BuildPartA: unit -> unit
    abstract member BuildPartB: unit -> unit
    abstract member GetResult: unit -> Product

type ConcreteBuilder1() = 
    inherit Builder()
    let privateProduct = new Product()
    override this.BuildPartA () = privateProduct.Add("PartA")
    override this.BuildPartB () = privateProduct.Add("PartB")
    override this.GetResult () = privateProduct
    
type ConcreteBuilder2() = 
    inherit Builder()
    let privateProduct = new Product()
    override this.BuildPartA () = privateProduct.Add("PartX")
    override this.BuildPartB () = privateProduct.Add("PartY")

    override this.GetResult () = privateProduct

type Director() =
    member this.Construct (builder: Builder) =
        builder.BuildPartA()
        builder.BuildPartB()
// test
let director = new Director()
let b1 = new ConcreteBuilder1()
let b2 = new ConcreteBuilder2()

// two products
director.Construct(b1)
let p1 = b1.GetResult()
p1.Show()
director.Construct(b2)
let p2 = b2.GetResult()
p2.Show()