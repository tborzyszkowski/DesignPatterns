/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterPluggablePrzyklad;

/**
 *
 * @author KrzysieK
 */
public class OdtwarzaczMP3 {
    public void Play(String nazwaPliku, String format){
        if (format.equalsIgnoreCase("mp3"))
        System.out.println("Plik o nazwie " + nazwaPliku + "." + format + " jest odtwarzany");
        else
            System.out.println("Odtwarzacz MP3 odtwarza tylko muzykę w formacie \".mp3\"");
    };
}
