open System.Collections.Generic
open System.IO
open System.Runtime.Serialization.Formatters.Binary
let serializeBinary<'a> (x :'a) =
    let binFormatter = new BinaryFormatter()

    use stream = new MemoryStream()
    binFormatter.Serialize(stream, x)
    stream.ToArray()

let deserializeBinary<'a> (arr : byte[]) =
    let binFormatter = new BinaryFormatter()

    use stream = new MemoryStream(arr)
    binFormatter.Deserialize(stream) :?> 'a

type UkladZaplonowy = {
    UrzadzenieSterujace     : string;
    SwiecaZaplonowa         : string;
    CzujnikSpalania         : string
} 

type Silnik = {
    Pojemnosc              : float;
    IloscCylindrow         : int;
    UkladZaplonowy         : UkladZaplonowy;
} 

type Samochod = {
    Producent    : string;
    Model        : string;
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