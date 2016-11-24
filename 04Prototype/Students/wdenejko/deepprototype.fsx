#r "System.Xml.dll"
#r "System.Runtime.Serialization.dll"

open Microsoft.FSharp.Reflection
open System.IO
open System.Reflection
open System.Runtime.Serialization
open System.Runtime.Serialization.Formatters.Binary
open System.Runtime.Serialization.Json
open System.Text
open System.Xml
open System.Xml.Serialization
let serializeBinary<'a> (x :'a) =
    let binFormatter = new BinaryFormatter()

    use stream = new MemoryStream()
    binFormatter.Serialize(stream, x)
    stream.ToArray()

let deserializeBinary<'a> (arr : byte[]) =
    let binFormatter = new BinaryFormatter()

    use stream = new MemoryStream(arr)
    binFormatter.Deserialize(stream) :?> 'a

[<DataContract>]
type UkladZaplonowy = {
    [<field : DataMember>]
    UrzadzenieSterujace     : string;
    [<field : DataMember>]
    SwiecaZaplonowa         : string;
    [<field : DataMember>]
    CzujnikSpalania         : string
} 

[<DataContract>]
type Silnik = {
    [<field : DataMember>]
    Pojemnosc              : float;
    [<field : DataMember>]
    IloscCylindrow         : int;
    [<field : DataMember>]
    UkladZaplonowy         : UkladZaplonowy;
} 

[<DataContract>]
type Samochod = {
    [<field : DataMember>]
    Producent    : string;
    [<field : DataMember>]
    Model        : string;
    [<field : DataMember>]
    Silnik        : Silnik
}

let MojSamochod = { 
    Producent = "Opel"; 
    Model = "Corsa"; 
            Silnik = { 
                Pojemnosc = 1.2;
                IloscCylindrow = 4;
                        UkladZaplonowy = {
                            UrzadzenieSterujace = "Bosch"; 
                            SwiecaZaplonowa = "Bosch"; 
                            CzujnikSpalania = "Jakis"
                            }
                        } 
                    }

let arr = serializeBinary MojSamochod
let CarClone = deserializeBinary<Samochod> arr