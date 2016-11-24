[<AbstractClass>]
type Prototype(id:string) =
    abstract member Clone: unit -> Prototype
    member this.Pr() =
        printf "%s\n" id

type ConcreatePrototype1(id:string) =
    inherit Prototype(id:string) 
    override this.Clone() = 
        this.MemberwiseClone() :?> Prototype

type ConcreatePrototype2(id:string) =
    inherit Prototype(id:string) 
    override this.Clone() = 
        this.MemberwiseClone() :?> Prototype

// TEST
let p1 = new ConcreatePrototype1("I")
let c1 = p1.Clone();
let p2 = new ConcreatePrototype2("II")
let c2 = p2.Clone();

c1.Pr()
c2.Pr()