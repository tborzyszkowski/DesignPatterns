open System.Collections.Generic
open System.IO
open System.Runtime.Serialization.Formatters.Binary

[<AbstractClass>]
type ColorPrototype() =
    abstract member Clone: unit -> ColorPrototype 

type Color(red : int, green : int, blue : int) =
    inherit ColorPrototype()
    override this.Clone() =
        printfn "Cloning color RGB: %i %i %i" red green blue
// Memberwise(shallow, simple) clone duplicate as little as possible. A memberwise clone of a collection is a copy of the collection structure, not the elements. With a memberwise clone, two collections now share the individual elements.
        this.MemberwiseClone() :?> ColorPrototype   

type ColorManager() =
    let colors = new Dictionary<string, Color>()
    let binFormatter = new BinaryFormatter()
    member this.Item
        with get(x) = colors.[(x)]
        and set(x, y) value = colors.Add(x, y)
    member this.Add key value =
        colors.Add(key, value)
    member this.Clear =
        colors.Clear()
// Deep clones duplicate everything. A deep clone of a collection is two collections with all of the elements in the original collection duplicated.
    member this.SerializeBinary<'a>(x : 'a) =
        printfn "Serializing object" 
        use stream = new MemoryStream()
        binFormatter.Serialize(stream, x)
        stream.ToArray()
    member this.DeserializeBinary<'a>(arr : byte[]) =
        printfn "Deserializing object" 
        use stream = new MemoryStream(arr)
        binFormatter.Deserialize(stream) :?> 'a

let colormanager = new ColorManager()
colormanager.Clear
colormanager.Add "red" (new Color(255, 0, 0))
colormanager.Add "green" (new Color(0, 255, 0))
colormanager.Add "blue" (new Color(0, 0, 255))

colormanager.Add "angry" (new Color(255, 54, 0))
colormanager.Add "peace" (new Color(128, 211, 128))
colormanager.Add "flame" (new Color(211, 34, 20))
let color1 = colormanager.["red"].Clone()
let color2 = colormanager.["peace"].Clone()
let color3 = colormanager.["flame"].Clone()

let binaryObj = colormanager.SerializeBinary(color1)
let deepClone1 = colormanager.DeserializeBinary<ColorPrototype> binaryObj
